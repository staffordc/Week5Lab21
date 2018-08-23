using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week5Lab21CoffeeShop.Models;
using Week5Lab21CoffeeShop.DAL;

namespace Week5Lab21CoffeeShop.Controllers
{
    public class UserController : Controller
    {


        // GET: Users/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]

        public ActionResult CreateUser(UserFormData userFormData)
        {
            var context = new CoffeeShopContextContainer();

            var user = new User
            {
                FirstName = userFormData.FirstName,
                LastName = userFormData.LastName,
                FavoriteCoffee = userFormData.FavoriteCoffee,
                PhoneNumber = userFormData.PhoneNumber,
                Email = userFormData.Email,
                Password = userFormData.Password,
                ConfirmPassword = userFormData.ConfirmPassword
            };


            context.Users.Add(user);

            context.SaveChanges();

            HttpCookie UserIdCookie;

            if (Request.Cookies["UserIdCookie"] == null)
            {
                UserIdCookie = new HttpCookie("UserIdCookie");
            }
            else
            {
                UserIdCookie = Request.Cookies["UserIdCookie"];
            }
            UserIdCookie.Value = user.Id.ToString();
            

            Response.Cookies.Add(UserIdCookie);
    
            return RedirectToAction("WelcomeUser", "Home");
        }
    }  
}

