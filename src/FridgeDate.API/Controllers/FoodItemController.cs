using AutoMapper;
using FridgeDate.Core.Models;
using System.Collections.Generic;
using System.Web.Http;
using FridgeDate.Data.Repository;
using FridgeDate.Data.Interfaces;

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

        public IEnumerable<FoodItem> Get()
        {
            return _mapper.Map<IEnumerable<FoodItem>>(_unitOfWork.FoodItemRepository.Get());
        }

        public FoodItem Get(string id)
        {           
            return _mapper.Map<FoodItem>(_unitOfWork.FoodItemRepository.GetByID(id));
        }

        public void Post([FromBody]FoodItem foodItem)
        {
            _unitOfWork.FoodItemRepository.Insert(_mapper.Map<Data.Models.FoodItem>(foodItem));
            _unitOfWork.Save();
        }


        public void Put(string id, [FromBody]FoodItem foodItem)
        {
            _unitOfWork.FoodItemRepository.Update(_mapper.Map<Data.Models.FoodItem>(foodItem));
            _unitOfWork.Save();
        }


        public void Delete(string id)
        {
            _unitOfWork.FoodItemRepository.Delete(_unitOfWork.FoodItemRepository.GetByID(id));
            _unitOfWork.Save();
        }
    }
}
