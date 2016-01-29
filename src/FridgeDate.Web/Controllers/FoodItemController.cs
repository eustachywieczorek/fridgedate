using AutoMapper;
using FridgeDate.Core.Models;
using FridgeDate.Web.Interfaces;
using FridgeDate.Web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FridgeDate.Web.Controllers
{
    public class FoodItemController : Controller
    {
        private IMapper _mapper;
        private IFridgeDateApi<FoodItem, string> _api;
        public FoodItemController(IMapper mapper)
        {
            _mapper = mapper;
            _api = RestService.For<IFridgeDateApi<FoodItem, string>>("http://localhost:47477/api/FoodItem");
        }
        // GET: FoodItem
        public async Task<ActionResult> Index()
        {
            var foodItems = await _api.ReadAll();
            return View(_mapper.Map<IEnumerable<FoodItemViewModel>>(foodItems));
        }

        public ActionResult Detail(string id)
        {
            var foodItem = _api.ReadOne(id);
            return View(_mapper.Map<FoodItemViewModel>(foodItem));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FoodItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var foodItem = _mapper.Map<FoodItem>(model);
                foodItem.Id = Guid.NewGuid().ToString();
                foodItem.BarCode = new BarCode() { Identifier = model.BarCodeId, Type = BarCodeType.Regular };
                var createdFoodItem = await _api.Create(foodItem);
            }
            return View(model);
        }
    }
}