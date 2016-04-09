using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;

namespace FridgeDate.Data.Repository
{
    public class FoodItemUserRepository: Repository<FoodItemUser>, IFoodItemsForUserRepository
    {
        public FoodItemUserRepository(FridgeDateContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FoodItemUser>> GetFoodItemsForUser(string userId)
        {
            return await context.FoodItemsForUser.Where(fiu => fiu.UserId == userId).ToListAsync();
        }
    }
}
