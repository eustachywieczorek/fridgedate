using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using System;

namespace FridgeDate.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FridgeDateContext context = new FridgeDateContext();
        private IRepository<User> userRepository;
        private IRepository<FoodItem> foodItemRepository;
        private IRepository<FoodItemUser> foodItemForUserRepository;

        public void Save()
        {
            context.SaveChanges();
        }


        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<User>(context);
                return userRepository;
            }
        }
        public IRepository<FoodItem> FoodItemRepository
        {
            get
            {
                if (foodItemRepository == null)
                    foodItemRepository = new Repository<FoodItem>(context);
                return foodItemRepository;
            }
        }

        public IRepository<FoodItemUser> FoodItemForUserRepository
        {
            get
            {
                if (foodItemForUserRepository == null)
                    foodItemForUserRepository = new Repository<FoodItemUser>(context);
                return foodItemForUserRepository;
            }
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
