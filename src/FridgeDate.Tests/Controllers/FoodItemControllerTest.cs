using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FridgeDate.API.Controllers;
using FridgeDate.Data.Repository;
using FridgeDate.API;
using FridgeDate.Tests.Fakes;
using FridgeDate.Data.Interfaces;
using FridgeDate.Data.Models;

namespace FridgeDate.Tests.Controllers
{
    [TestClass]
    public class FoodItemControllerTest
    {
        private IUnitOfWork _unitOfWork;
        private FoodItemController _controller;
        private FakeRepository<FoodItem> _foodItemRepository;
        private FoodItem _foodItem;
        public FoodItemControllerTest()
        {
            _unitOfWork = new FakeUnitOfWork();
        }

        [TestInitialize]
        public void Setup()
        {
            _controller = new FoodItemController(MapperBootstap.CreateMapper(), _unitOfWork);
            _foodItemRepository = _unitOfWork.FoodItemRepository as FakeRepository<FoodItem>;
            _foodItem = _foodItemRepository.Insert(new FoodItem()
            {
                BarCode = new BarCode { Identifier = "123", Type = BarCodeType.Regular },
                Name = "Juice",
                ShelfLifeDays = 4
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            _foodItemRepository.Clear();
            _foodItem = null;
        }

        [TestMethod]
        public void Get()
        {
            IEnumerable<Core.Models.FoodItem> result = _controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Juice", result.ElementAt(0).Name);
        }

        [TestMethod]
        public void GetById()
        {
            Core.Models.FoodItem result = _controller.Get(_foodItem.Id);
            Assert.AreEqual("Juice", result.Name);
        }

        [TestMethod]
        public void Post()
        {
            var foodItem = new Core.Models.FoodItem()
            {
                BarCode = new Core.Models.BarCode { Identifier = "456", Type = Core.Models.BarCodeType.Regular },
                Id = "2",
                Name = "Lettuce",
                ShelfLifeDays = 5
            };
            _controller.Post(foodItem);

            Assert.AreEqual(_controller.Get().Count(), 2);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            _controller.Delete(_foodItem.Id);
            Assert.AreEqual(0, _controller.Get().Count());
        }
    }
}
