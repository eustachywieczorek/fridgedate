using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.DAL.Models;
using FridgeDate.DAL.Models.Models;
using Microsoft.Data.Entity;

namespace FridgeDate.DAL
{
    public class FridgeDateContext : DbContext
    {
        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FoodItemUser> FoodItemsForUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>()
                .Property(f => f.Id)
                .IsRequired();

            modelBuilder.Entity<FoodItem>()
                .HasMany<FoodItemUser>();

            modelBuilder.Entity<User>()
                .HasMany<FoodItemUser>();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired();


            modelBuilder.Entity<FoodItemUser>()
                .Property(fi => fi.FoodItem)
                .IsRequired();

            modelBuilder.Entity<FoodItemUser>()
                .HasOne(fi => fi.User);
        }
    }
}
    