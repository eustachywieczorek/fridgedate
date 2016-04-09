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
        private IRepository<User> _userRepository;
        private IRepository<FoodItem> _foodItemRepository;
        private IFoodItemsForUserRepository _foodItemForUserRepository;

        public IFoodItemsForUserRepository FoodItemForUserRepository => _foodItemForUserRepository ?? (_foodItemForUserRepository = new FakeFoodItemUserRepository());
        public IRepository<FoodItem> FoodItemRepository => _foodItemRepository ?? (_foodItemRepository = new FakeRepository<FoodItem>());
        public IRepository<User> UserRepository => _userRepository ?? (_userRepository = new FakeRepository<User>());

        public Task Save()
        {
            return Task.Run(() =>
            {
                return;
            });
        }
    }
}
