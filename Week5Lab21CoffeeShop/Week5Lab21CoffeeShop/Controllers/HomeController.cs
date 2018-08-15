using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week5Lab21CoffeeShop.Models;

namespace Week5Lab21CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserRegistration()
        {
            ViewBag.Message = "Welcome to the app";

            
            return View();
        }

        
        public ActionResult WelcomeUser()
        {
            
            ViewBag.Message = $"what up {UserController.StoredUser.FirstName}";
            return View();
        }
    }
}