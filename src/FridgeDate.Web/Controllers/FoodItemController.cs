using AutoMapper;
using FridgeDate.Core.Models;
using FridgeDate.Web.Interfaces;
using FridgeDate.Web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZXing;

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

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/uploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);

                    IBarcodeReader reader = new BarcodeReader();
                    var barcodeBitmap = (Bitmap)Bitmap.FromFile(imagePath);
                    var result = reader.Decode(barcodeBitmap);
                    if (result != null)
                    {
                        foodItem.BarCode = new BarCode { Identifier = result.Text, Type = result.BarcodeFormat == BarcodeFormat.QR_CODE ? BarCodeType.QR : BarCodeType.Regular };
                        model.BarCodeId = result.Text;
                    }
                } else if (!string.IsNullOrEmpty(model.BarCodeId))
                {
                    foodItem.BarCode = new BarCode() { Identifier = model.BarCodeId, Type = BarCodeType.Regular };
                }

                var createdFoodItem = await _api.Create(foodItem);
            }
            return View("Detail", model);
        }
    }
}