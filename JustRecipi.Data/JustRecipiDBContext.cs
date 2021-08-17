using System;
using System.Collections.Generic;
using System.Text;
using JustRecipi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JustRecipi.Data
{
    public class JustRecipiDbContext : DbContext
    {
        public JustRecipiDbContext() { }
        public JustRecipiDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}