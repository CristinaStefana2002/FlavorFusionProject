using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Models;
using FlavorFusion.Pages;

namespace FlavorFusion.Data
{
    public class FlavorFusionContext : DbContext
    {
        public FlavorFusionContext (DbContextOptions<FlavorFusionContext> options)
            : base(options)
        {
        }

        public DbSet<FlavorFusion.Models.User> User { get; set; } = default!;
        public DbSet<FlavorFusion.Models.Category> Category { get; set; } = default!;
        public DbSet<FlavorFusion.Models.Recipe> Recipe { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories)
                .HasForeignKey(rc => rc.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(rc => rc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FlavorFusion.Models.MealPlan> MealPlan { get; set; } = default!;



    }

}

