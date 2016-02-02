using AutoMapper;
using FridgeDate.Core.Models;
using System.Collections.Generic;
using System.Web.Http;
using FridgeDate.Data.Repository;
using FridgeDate.Data.Interfaces;
using System.Threading.Tasks;

namespace FridgeDate.API.Controllers
{
    public class FoodItemController : ApiController
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public FoodItemController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IHttpActionResult> Get()
        {
            var foodItems = await _unitOfWork.FoodItemRepository.Get();
            var t = _mapper.Map<IEnumerable<FoodItem>>(foodItems);
            return Ok(t);
        }

        public async Task<IHttpActionResult> Get(string id)
        {           
            var foodItem = await _unitOfWork.FoodItemRepository.GetByID(id);
            if (foodItem == null)
                return NotFound();
            return Ok(_mapper.Map<FoodItem>(foodItem));
        }

        public async Task<IHttpActionResult> Post([FromBody]FoodItem foodItem)
        {
            var savedFoodItem = _unitOfWork.FoodItemRepository.Insert(_mapper.Map<Data.Models.FoodItem>(foodItem));
            await _unitOfWork.Save();
            return Ok(savedFoodItem);
        }


        public async Task<IHttpActionResult> Put(string id, [FromBody]FoodItem foodItem)
        {
            var updatedFoodItem = _unitOfWork.FoodItemRepository.Update(_mapper.Map<Data.Models.FoodItem>(foodItem));
            await _unitOfWork.Save();
            return Ok(updatedFoodItem);
        }


        public async Task<IHttpActionResult> Delete(string id)
        {

            var deletedFoodItem = _unitOfWork.FoodItemRepository.DeleteById(id);
            await _unitOfWork.Save();
            return Ok(deletedFoodItem);
        }
    }
}
