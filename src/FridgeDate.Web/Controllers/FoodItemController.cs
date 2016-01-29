using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FridgeDate.Web.Controllers
{
    public class FoodItemController : Controller
    {
        // GET: FoodItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}