using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeDate.API.Controllers
{
    public class FoodItemController : ApiController
    {
        private IRepository<FoodItem> _foodItemRepository;
        public FoodItemController(IRepository<FoodItem> foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        public IEnumerable<FoodItem> Get()
        {
            return _foodItemRepository.Get();
        }

        public FoodItem Get(int id)
        {
            return _foodItemRepository.GetByID(id);
        }

        // POST api/values
        public void Post([FromBody]FoodItem value)
        {
            _foodItemRepository.Insert(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]FoodItem value)
        {
            _foodItemRepository.Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _foodItemRepository.Delete(_foodItemRepository.GetByID(id));
        }
    }
}
