﻿using System;
using System.Collections.Generic;
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
        public ActionResult CreateUser(User collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("WelcomeUser","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
