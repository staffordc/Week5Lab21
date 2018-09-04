using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week5Lab21CoffeeShop.Data;
using Week5Lab21CoffeeShop.Domain.Models;

namespace Week5Lab21CoffeeShop.Controllers
{
    public class CartController : Controller
    {
        private Week5Lab21CoffeeShopContext db = new Week5Lab21CoffeeShopContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(db.Items);
        }
        
    }
}
