﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week5Lab21CoffeeShop;
using Week5Lab21CoffeeShop.Controllers;

namespace Week5Lab21CoffeeShop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void UserRegistration()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.UserRegistration() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void WelcomeUser()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.WelcomeUser() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
