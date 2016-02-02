using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FridgeDate.API.Controllers;
using FridgeDate.Data.Repository;
using FridgeDate.API;
using FridgeDate.Tests.Fakes;
using FridgeDate.Data.Interfaces;
using FridgeDate.Core.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Results;

namespace FridgeDate.Tests.Controllers
{
    [TestClass]
    public class FoodItemControllerTest
    {
        private IUnitOfWork _unitOfWork;
        private FoodItemController _controller;
        private FakeRepository<Data.Models.FoodItem> _foodItemRepository;
        private FoodItem _foodItem;
        private IMapper _mapper;
        public FoodItemControllerTest()
        {
            _unitOfWork = new FakeUnitOfWork();
            _mapper = MapperBootstap.CreateMapper();
        }

        [TestInitialize]
        public void Setup()
        {
            _controller = new FoodItemController(_mapper, _unitOfWork);
            _foodItemRepository = _unitOfWork.FoodItemRepository as FakeRepository<Data.Models.FoodItem>;
            _foodItem = _mapper.Map<FoodItem>(_foodItemRepository.Insert(new Data.Models.FoodItem()
            {
                BarCode = new Data.Models.BarCode { Identifier = "123", Type = Data.Models.BarCodeType.Regular },
                Name = "Juice",
                ShelfLifeDays = 4
            }));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _foodItemRepository.Clear();
            _foodItem = null;
        }

        [TestMethod]
        public async Task Get()
        {
            var result = await _controller.Get(); //as OkNegotiatedContentResult<IEnumerable<FoodItem>>;
            /*
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Count());
            Assert.AreEqual("Juice", result.Content.ElementAt(0).Name);
            */
        }

        [TestMethod]
        public async Task GetById()
        {
            var result = await _controller.Get(_foodItem.Id) as OkNegotiatedContentResult<FoodItem>;
            Assert.AreEqual("Juice", result.Content.Name);
        }

        [TestMethod]
        public async Task Post()
        {
            var foodItem = new FoodItem()
            {
                BarCode = new BarCode { Identifier = "456", Type = BarCodeType.Regular },
                Id = "2",
                Name = "Lettuce",
                ShelfLifeDays = 5
            };
            await _controller.Post(foodItem);

            var result = await _controller.Get() as OkNegotiatedContentResult<IEnumerable<FoodItem>>;
            Assert.AreEqual(2, result.Content.Count());
        }

        [TestMethod]
        public async Task Put()
        {
            _foodItem.Name = "Milk";
            await _controller.Put(_foodItem.Id, _foodItem);
            var result = await _controller.Get(_foodItem.Id) as OkNegotiatedContentResult<FoodItem>;
            Assert.AreEqual("Milk", result.Content.Name);
        }

        [TestMethod]
        public async Task Delete()
        {
            await _controller.Delete(_foodItem.Id);
            var result = await _controller.Get() as OkNegotiatedContentResult<IEnumerable<FoodItem>>;
            Assert.AreEqual(0, result.Content.Count());
        }
    }
}
