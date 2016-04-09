using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Data.Models;

namespace FridgeDate.Data.Interfaces
{
    public interface IFoodItemsForUserRepository : IRepository<FoodItemUser>
    {
        Task<IEnumerable<FoodItemUser>> GetFoodItemsForUser(string userId);
    }
}
