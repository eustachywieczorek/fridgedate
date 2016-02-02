using FridgeDate.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Data.Models;

namespace FridgeDate.Tests.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IRepository<User> userRepository;
        private IRepository<FoodItem> foodItemRepository;
        private IRepository<FoodItemUser> foodItemForUserRepository;

        public IRepository<FoodItemUser> FoodItemForUserRepository
        {
            get
            {
                if (foodItemForUserRepository == null)
                    foodItemForUserRepository = new FakeRepository<FoodItemUser>();
                return foodItemForUserRepository;
            }
        }

        public IRepository<FoodItem> FoodItemRepository
        {
            get
            {
                if (foodItemRepository == null)
                    foodItemRepository = new FakeRepository<FoodItem>();
                return foodItemRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new FakeRepository<User>();
                return userRepository;
            }
        }

        public Task Save()
        {
            return Task.Run(() =>
            {
                return;
            });
        }
    }
}
