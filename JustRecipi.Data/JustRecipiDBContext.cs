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
            base.OnModelCreating(modelBuilder);
            //TODO: Put HasMany/HasOne and WithMany/WithOne Relations Here
            modelBuilder.Entity<Recipe>()
                .HasMany(review => review.Reviews)
                .WithOne(recipe => recipe.Recipe);
            modelBuilder.Entity<CookBook>()
                .HasMany(r => r.Recipes)
                .WithOne(c => c.CookBook);
        }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}