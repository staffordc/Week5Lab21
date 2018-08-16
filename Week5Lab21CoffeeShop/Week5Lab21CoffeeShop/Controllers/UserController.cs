using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week5Lab21CoffeeShop.Models;

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
        public ActionResult CreateUser(User user)
        {
            HttpCookie UserInformationCookie;
            if (Request.Cookies["UserInformationCookie"] == null)
            {
                UserInformationCookie = new HttpCookie("UserInformationCookie");
            }
            else
            {
                UserInformationCookie = Request.Cookies["UserInformationCookie"];
            }
            UserInformationCookie.Values.Set(nameof(user.FirstName), user.FirstName);
            UserInformationCookie.Values.Set(nameof(user.FavoriteCoffee), user.FavoriteCoffee);

            Response.Cookies.Add(UserInformationCookie);
    
            return RedirectToAction("WelcomeUser", "Home");
        }
    }  
}

