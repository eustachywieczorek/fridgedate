using FridgeDate.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FridgeDate.Data
{
    public class FridgeDateContext : IdentityDbContext<User>
    {
        public FridgeDateContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static FridgeDateContext Create()
        {
            return new FridgeDateContext();
        }

        public DbSet<BarCode> BarCodes { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }


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
    