using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Text;

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

    }
}
