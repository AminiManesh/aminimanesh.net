using Aminimanesh.Core.Profiles;
using Aminimanesh.Core.Security;
using Aminimanesh.Core.Services;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Context;
using Aminimanesh.DataLayer.Entities.Owner;
using ElectronicLearn.Core.Convertors;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(CustomProfile), typeof(Program));

// forward headers configuration for reverse proxy
builder.Services.Configure<ForwardedHeadersOptions>(options => {
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddHttpClient<IpApiClient>();

// other service configurations...

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

#region Database Context
builder.Services.AddDbContext<AminimaneshContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("AminimaneshConnection"));
});
#endregion

#region IoC
builder.Services.AddTransient<IOwnerService, OwnerService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IViewRenderService, RenderViewToString>();
#endregion

#region Authentication
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });
#endregion

#region File Upload
builder.Services.Configure<FormOptions>(option =>
{
    option.MultipartBodyLengthLimit = 1073741824;
});
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute
    (
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute
    (
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();