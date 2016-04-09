using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FridgeDate.Data;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using FridgeDate.Data.Repository;

namespace FridgeDate.Tests.Fakes
{
    public class FakeFoodItemUserRepository : FakeRepository<FoodItemUser>, IFoodItemsForUserRepository
    {
        public async Task<IEnumerable<FoodItemUser>> GetFoodItemsForUser(string userId)
        {
            return (IEnumerable<FoodItemUser>) Collection.Where(c => c.Value.UserId == userId);

        }
    }
}
