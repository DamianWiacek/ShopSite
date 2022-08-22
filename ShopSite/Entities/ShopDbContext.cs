using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Entities
{
    public class ShopDbContext : DbContext
    {
        private string _connectionString = "Server=DESKTOP-2UA5DVQ;Database=ShopApiDb;Trusted_Connection=True;";
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Adres> Adreses { get; set; }

        public DbSet<User> Users  { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<User>()
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<Role>()
                 .HasData(
                new Role() { Id = 1, Name = "Customer" },
                new Role() { Id = 2, Name = "Manager"},
                new Role() { Id = 3, Name ="Admin"}
                );
               
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
