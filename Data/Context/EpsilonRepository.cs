using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Text;
using Data.Entities;

namespace Data.Context
{
    public class UsersManagementContext : DbContext
    {
        public UsersManagementContext () 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IS-WKS107;Database=Epsilon;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductsMatching> ProductsMatching { get; set; }

    }
}
