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
            var user = db.Users.Include(u => u.Items).FirstOrDefault(u => u.UserId == LoginValue);
            ViewBag.User = user;
            //V Upset at last run because the set is Null?
            //ViewBag.Items = user.Items.ToList();
            //Set up Dictionary for Count of Items
            var ItemsCounts = user.Items.GroupBy(i => i.ItemId).ToDictionary(k => k.Key, v => v.Count());
            ViewBag.ItemsCounts = ItemsCounts;

            var cartItems = db.Items.ToList().Select(i => {
                return new CartItem
                {
                    ItemId = i.ItemId,
                    Count = ItemsCounts.TryGetValue(i.ItemId, out var c) ? c : 0,
                    Item = i

                };
                }
            );

            return View(cartItems);
        }
        public ActionResult Add(int? id)
        {
            if (id == null || Request.Cookies["UserLogin"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserLogin = Request.Cookies["UserLogin"];
            var userId = int.Parse(UserLogin.Value);
            var user = db.Users.Include(u => u.Items).FirstOrDefault(u => u.UserId == userId);

            Item item = db.Items.Find(id);
            if (user == null || item == null)
            {
                return HttpNotFound();
            }

            var existingCartItem = db.CartItems.FirstOrDefault(x => x.UserId == user.UserId && x.ItemId == item.ItemId);
            if (existingCartItem == null)
            {
                var cartItem = new CartItem { UserId = user.UserId, ItemId = item.ItemId, Count = 1 };
                db.CartItems.Add(cartItem);
                db.SaveChanges();
            }
            else
            {
                existingCartItem.Count++;
                db.SaveChanges();
            }

            var cartItems = db.Items.ToList().Select(i =>
            {
                return new CartItem
                {
                    ItemId = i.ItemId,
                    Count = db.CartItems.FirstOrDefault(x => x.UserId == user.UserId && x.ItemId == i.ItemId)?.Count ?? 0,
                    Item = i

                };
            });

            return View("Index",cartItems);
            
        }
        public ActionResult Delete(int? id)
        {
            if (id == null || Request.Cookies["UserLogin"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserLogin = Request.Cookies["UserLogin"];
            var userId = int.Parse(UserLogin.Value);
            var user = db.Users.Include(u => u.Items).FirstOrDefault(u => u.UserId == userId);

            Item item = db.Items.Find(id);
            if (user == null || item == null)
            {
                return HttpNotFound();
            }

            var existingCartItem = db.CartItems.FirstOrDefault(x => x.UserId == user.UserId && x.ItemId == item.ItemId);
            if (existingCartItem == null)
            {
                var cartItem = new CartItem { UserId = user.UserId, ItemId = item.ItemId, Count = 0 };
                db.CartItems.Add(cartItem);
                db.SaveChanges();
            }
            else
            {
                if (existingCartItem.Count > 0)
                {
                    existingCartItem.Count--;
                    db.SaveChanges();
                }
            }

            //var ItemsCounts = user.Items.GroupBy(i => i.ItemId).ToDictionary(k => k.Key, v => v.Count());
            //ViewBag.ItemsCounts = ItemsCounts;

            var cartItems = db.Items.ToList().Select(i =>
            {
                return new CartItem
                {
                    ItemId = i.ItemId,
                    Count = db.CartItems.FirstOrDefault(x => x.UserId == user.UserId && x.ItemId == i.ItemId)?.Count ?? 0,
                    Item = i

                };
            }
            );

            return View("Index", cartItems);
        }
    }
}
