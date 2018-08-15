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
            string firstName ="";
            HttpCookie userInformationCookie;
            if (Request.Cookies["UserInformationCookie"] != null)
            {
                userInformationCookie = Request.Cookies["UserInformationCookie"];
                firstName = userInformationCookie.Value;

            }
            ViewBag.Message = ($"what up {firstName}");
            return View();
        }
    }
}