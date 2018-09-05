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
            var UserLogin = Request.Cookies["UserLogin"];
            var LoginValue = int.Parse(UserLogin.Value);
            var user = db.Users.FirstOrDefault(u => u.UserId == LoginValue);
            ViewBag.User = user;
            //V Upset at last run because the set is Null?
            ViewBag.Items = user.Items.ToList();
            //Set up Dictionary for Count of Items
            var ItemsCounts = user.Items.GroupBy(i => i.ItemId).ToDictionary(k => k.Key, v => v.Count());
            return View(db.Items);
        }
        public ActionResult Add(int? id)
        {
            if (id == null || Request.Cookies["UserLogin"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserLogin = Request.Cookies["UserLogin"];
            var user = db.Users.FirstOrDefault(u => u.UserId == int.Parse(UserLogin.Value));

            Item item = db.Items.Find(id);
            if (user == null || item == null)
            {
                return HttpNotFound();
            }

            user.Items.Add(item);
            db.SaveChanges();

            return View(db.Items);
            
        }

    }
}
