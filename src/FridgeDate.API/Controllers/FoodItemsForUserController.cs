using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FridgeDate.Core.Models;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Repository;

namespace FridgeDate.API.Controllers
{
    [Route("foodItemUser")]
    public class FoodItemsForUserController : BaseApiController
    {
        public FoodItemsForUserController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            
        }

        public async Task<IHttpActionResult> Get()
        {
            var foodItemsForUser = await UnitOfWork.FoodItemForUserRepository.Get();
            var t = Mapper.Map<IEnumerable<FoodItemUser>>(foodItemsForUser);
            return Ok(t);
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            var foodItemForUser = await UnitOfWork.FoodItemForUserRepository.GetByID(id);
            if (foodItemForUser == null)
                return NotFound();
            return Ok(Mapper.Map<FoodItemUser>(foodItemForUser));
        }

        public async Task<IHttpActionResult> Post([FromBody]FoodItemUser foodItemForUser)
        {
            var savedFoodItemForUser = UnitOfWork.FoodItemForUserRepository.Insert(Mapper.Map<Data.Models.FoodItemUser>(foodItemForUser));
            await UnitOfWork.Save();
            return Ok(savedFoodItemForUser);
        }


        public async Task<IHttpActionResult> Put(string id, [FromBody]FoodItemUser item)
        {
            var updatedItem = UnitOfWork.FoodItemForUserRepository.Update(Mapper.Map<Data.Models.FoodItemUser>(item));
            await UnitOfWork.Save();
            return Ok(updatedItem);
        }


        public async Task<IHttpActionResult> Delete(string id)
        {
            var deletedItem = UnitOfWork.FoodItemForUserRepository.DeleteById(id);
            await UnitOfWork.Save();
            return Ok(deletedItem);
        }

    }
}
