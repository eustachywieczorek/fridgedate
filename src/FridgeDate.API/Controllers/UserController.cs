using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FridgeDate.Data.Interfaces;

namespace FridgeDate.API.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        
        [Route("/{userId}/FoodItems")]
        public async Task<IHttpActionResult> GetFoodItemsForUser(string userId)
        {
            var foodItems = UnitOfWork.FoodItemForUserRepository.Get();
        }
    }
}
