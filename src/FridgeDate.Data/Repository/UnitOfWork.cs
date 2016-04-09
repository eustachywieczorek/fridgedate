using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using System;
using System.Threading.Tasks;

namespace FridgeDate.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FridgeDateContext _context = new FridgeDateContext();
        private IRepository<User> _userRepository;
        private IRepository<FoodItem> _foodItemRepository;
        private IFoodItemsForUserRepository _foodItemForUserRepository;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<User> UserRepository => _userRepository ?? (_userRepository = new Repository<User>(_context));
        public IRepository<FoodItem> FoodItemRepository => _foodItemRepository ?? (_foodItemRepository = new Repository<FoodItem>(_context));

        public IFoodItemsForUserRepository FoodItemForUserRepository => _foodItemForUserRepository ?? (_foodItemForUserRepository = new FoodItemUserRepository(_context));


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
