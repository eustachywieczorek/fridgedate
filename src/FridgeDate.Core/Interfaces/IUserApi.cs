using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Core.Models;

namespace FridgeDate.Core.Interfaces
{
    public interface IUserApi: IFridgeDateApi<User, string>
    {
        Task<List<FoodItemUser>> GetFoodItemsForUser();
    }
}
