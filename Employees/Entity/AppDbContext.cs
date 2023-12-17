using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entity
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employees> Employe { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Employes;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Organization>()
                .HasIndex(u => u.INN)
                .IsUnique();
        }
    }
}
