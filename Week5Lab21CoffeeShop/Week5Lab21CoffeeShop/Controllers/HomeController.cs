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
            string firstName = "";
            string favoriteCoffee = "";
            HttpCookie userInformationCookie;
            if (Request.Cookies["UserInformationCookie"] != null)
            {
                userInformationCookie = Request.Cookies["UserInformationCookie"];
                firstName = userInformationCookie.Values.Get("FirstName");
                favoriteCoffee = userInformationCookie.Values.Get("FavoriteCoffee");
            }
            ViewBag.Message = ($"what up {firstName}");
            ViewBag.FavoriteCoffee = favoriteCoffee;
            return View();
        }
        [HttpPost]
        public ActionResult AddCoffee()
        {
            int addCoffeeCount = 0;
            HttpCookie coffeeCountCookie;
            if (Request.Cookies["coffeeCountCookie"] != null)
            {
                coffeeCountCookie = Request.Cookies["coffeeCountCookie"];
                addCoffeeCount = int.Parse(coffeeCountCookie.Value);
            }
            else
            {
                coffeeCountCookie = new HttpCookie("coffeeCountCookie");
            }
            addCoffeeCount++;
            ViewBag.Count = addCoffeeCount;
            coffeeCountCookie.Value = addCoffeeCount.ToString();
            Response.Cookies.Add(coffeeCountCookie);
            return RedirectToAction("WelcomeUser");
        }
        public ActionResult Cart()
        {
            string addCoffeeCount;
            HttpCookie coffeeCountCookie;
            if (Request.Cookies["coffeeCountCookie"] != null)
            {
                addCoffeeCount = ViewBag.Count;
                coffeeCountCookie = Request.Cookies["coffeeCountCookie"];
                addCoffeeCount = coffeeCountCookie.Value;
            }
            else
            {
                RedirectToRoute(Contact());
            }
            return View();

        }
    }
}