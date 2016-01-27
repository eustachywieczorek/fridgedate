using FridgeDate.Data.Models;
using System.Data.Entity;

namespace FridgeDate.Data
{
    public class FridgeDateContext : DbContext
    {
        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FoodItemUser> FoodItemsForUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>()
                .Property(f => f.Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany<FoodItemUser>(u => u.FoodItems);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired();

            modelBuilder.Entity<FoodItemUser>()
                .HasRequired<User>(fi => fi.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
    