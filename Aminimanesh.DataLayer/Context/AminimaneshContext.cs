using Aminimanesh.DataLayer.Entities.Owner;
using Aminimanesh.DataLayer.Entities.User;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Context
{
    public class AminimaneshContext : DbContext
    {
        public AminimaneshContext(DbContextOptions<AminimaneshContext> options) : base(options)
        {

        }


        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryLine> HistoryLines { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Speech> Speechs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<IpApiResponse> IpApiResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<HistoryLine>().HasQueryFilter(hl => !hl.IsDeleted);
            modelBuilder.Entity<Message>().HasQueryFilter(m => !m.IsDeleted);


            modelBuilder.Entity<Owner>().HasData(new Owner
            {
                OwnerId = 1,
                FullName = " محمد امین امینی منش",
                Age = 22,
                Awards = "",
                Avatar = "./owner/img/thumbnails/avatar.jpg",
                City = "Arak",
                CompletedProjects = "4",
                Country = "Iran",
                Email = "aztecgoodamin1@gmail.com",
                CVFile = "",
                ExperienceYears = "5",
                FirstJob = "Back-End Developer",
                SecondJob = "C# Programmer",
                IncomeEmail = "aztecgoodamin1@gmail.com",
                Instagram = "amn.web",
                Mobile = "09187622841",
                Mobile2 = "09182565432",
                Province = "Markazi",
                SatisfiedCustomer = "2",
                Telegram = "aminimanesh81",
                Whatsapp = "+989187622841"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                UserName = "AminJP",
                Pasword = "$2a$11$f986mlME0epIeEKjSlG7MOrTi2f.hXo4bXok6Ec03KoJTmb41Pa7S",
                Email = "aztecgoodamin1@gmail.com"
            });
        }
    }
}
