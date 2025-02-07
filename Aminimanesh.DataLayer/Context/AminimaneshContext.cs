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
        }
    }
}
