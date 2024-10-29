using BusinessServices.ModelDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectAction>().
                HasOne(x => x.Project).
                WithMany(x => x.projectActions).
                HasForeignKey(x => x.ProjectId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectActionParameter>()
                .HasOne(x => x.ProjectAction).
                WithMany(x => x.ProjectActionParameters).
                HasForeignKey(x => x.ProjectActionId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectActionParameter>()
              .HasOne(x => x.ActionParameterType).
              WithMany(x => x.ProjectActionParameters).
              HasForeignKey(x => x.ActionParameterTypeId).
              OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAction> ProjectActions { get; set; }
        public DbSet<ProjectActionParameter> ProjectActionParameters { get; set; }
        public DbSet<ActionParameterType> ActionParameterTypes { get; set; }

    }
}
