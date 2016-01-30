using FridgeDate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<FoodItem> FoodItemRepository { get; }
        IRepository<FoodItemUser> FoodItemForUserRepository { get; }
        void Save();

    }
}
