using AutoMapper;
using FridgeDate.Core.Models;
using System.Collections.Generic;
using System.Web.Http;
using FridgeDate.Data.Repository;
using FridgeDate.Data.Interfaces;
using System.Threading.Tasks;

namespace FridgeDate.API.Controllers
{
    public class FoodItemController : BaseApiController
    {
        public FoodItemController(IMapper mapper, IUnitOfWork unitOfWork): base(mapper, unitOfWork)
        {
        }

        public async Task<IHttpActionResult> Get()
        {
            var foodItems = await UnitOfWork.FoodItemRepository.Get();
            var t = Mapper.Map<IEnumerable<FoodItem>>(foodItems);
            return Ok(t);
        }

        public async Task<IHttpActionResult> Get(string id)
        {           
            var foodItem = await UnitOfWork.FoodItemRepository.GetByID(id);
            if (foodItem == null)
                return NotFound();
            return Ok(Mapper.Map<FoodItem>(foodItem));
        }

        public async Task<IHttpActionResult> Post([FromBody]FoodItem foodItem)
        {
            var savedFoodItem = UnitOfWork.FoodItemRepository.Insert(Mapper.Map<Data.Models.FoodItem>(foodItem));
            await UnitOfWork.Save();
            return Ok(savedFoodItem);
        }


        public async Task<IHttpActionResult> Put(string id, [FromBody]FoodItem foodItem)
        {
            var updatedFoodItem = UnitOfWork.FoodItemRepository.Update(Mapper.Map<Data.Models.FoodItem>(foodItem));
            await UnitOfWork.Save();
            return Ok(updatedFoodItem);
        }


        public async Task<IHttpActionResult> Delete(string id)
        {
            var deletedFoodItem = UnitOfWork.FoodItemRepository.DeleteById(id);
            await UnitOfWork.Save();
            return Ok(deletedFoodItem);
        }
    }
}
