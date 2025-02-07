using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class CategoriesComponent : ViewComponent
    {
        private readonly IProjectService _projectService;
        public CategoriesComponent(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _projectService.GetCategoriesForFilter();
            return View("Categories", model);
        }
    }
}
