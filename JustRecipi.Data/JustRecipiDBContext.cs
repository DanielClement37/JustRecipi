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
        public JustRecipiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Put HasMany/HasOne and WithMany/WithOne Relations Here
            modelBuilder.Entity<Recipe>()
                .HasOne(c => c.CookBook)
                .WithMany(c=>c.Recipes)
                .HasForeignKey(r=> r.CookBookId);
            
            modelBuilder.Entity<Review>()
                .HasOne(r=>r.Recipe)
                .WithMany(r=>r.Reviews)
                .HasForeignKey(r=>r.RecipeId);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<CookBook> CookBooks { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}