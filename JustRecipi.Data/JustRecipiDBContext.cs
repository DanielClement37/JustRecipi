using System;
using System.Collections.Generic;
using System.Text;
using JustRecipi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustRecipi.Data
{
    public class JustRecipiDbContext : IdentityDbContext<User>
    {
        public JustRecipiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Recipe)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<CookBookRecipe>()
                .HasOne(c => c.CookBook)
                .WithMany(cr => cr.CookBookRecipes)
                .HasForeignKey(ci => ci.CookBookId);
            
            modelBuilder.Entity<CookBookRecipe>()
                .HasOne(r => r.Recipe)
                .WithMany(cr => cr.CookBookRecipes)
                .HasForeignKey(ri => ri.RecipeId);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<CookBook> CookBooks { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<CookBookRecipe> CookBookRecipes { get; set; }
    }
}