using AutoMapper;
using FridgeDate.Data.Interfaces;
using FridgeDate.Core.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace FridgeDate.API.Controllers
{
    public class FoodItemController : ApiController
    {
        private IRepository<Data.Models.FoodItem> _foodItemRepository;
        private IMapper _mapper;
        public FoodItemController(IRepository<Data.Models.FoodItem> foodItemRepository, IMapper mapper)
        {
            _foodItemRepository = foodItemRepository;
            _mapper = mapper;
        }

        public IEnumerable<FoodItem> Get()
        {
            return _mapper.Map<IEnumerable<FoodItem>>(_foodItemRepository.Get());
        }

        public FoodItem Get(int id)
        {
           
            return _mapper.Map<FoodItem>(_foodItemRepository.GetByID(id));
        }

        // POST api/values
        public void Post([FromBody]FoodItem value)
        {
            _foodItemRepository.Insert(_mapper.Map<Data.Models.FoodItem>(value));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]FoodItem value)
        {
            _foodItemRepository.Update(_mapper.Map<Data.Models.FoodItem>(value));
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _foodItemRepository.Delete(_foodItemRepository.GetByID(id));
        }
    }
}
