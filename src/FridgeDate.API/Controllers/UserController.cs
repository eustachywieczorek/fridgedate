using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FridgeDate.Core.Models;
using FridgeDate.Data.Interfaces;
using Microsoft.AspNet.Identity;

namespace FridgeDate.API.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        public UserController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        
        [Route("api/User/FoodItems")]
        public async Task<IHttpActionResult> GetFoodItemsForUser()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
            var foodItems = await UnitOfWork.FoodItemForUserRepository.GetFoodItemsForUser(User.Identity.GetUserId());
            var foodItemUsers = foodItems as Data.Models.FoodItemUser[] ?? foodItems.ToArray();
            if (foodItemUsers.Any())
                return Ok(Mapper.Map<IEnumerable<FoodItemUser>>(foodItemUsers));
            return NotFound();
        }
    }
}
