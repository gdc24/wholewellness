using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using wholewellness;
using wholewellness.Controllers;
using wholewellness.Models;

namespace wholewellness.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = (ViewResult)controller.Index();

            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            var expectedVersion = mvcName.Version.Major + "." + mvcName.Version.Minor;
            var expectedRuntime = isMono ? "Mono" : ".NET";

            // Assert
            Assert.AreEqual(expectedVersion, result.ViewData["Version"]);
            Assert.AreEqual(expectedRuntime, result.ViewData["Runtime"]);
        }

        [Test]
        public void AddMeal()
        {
            // Arrange
            var controller = new HomeController();
            List<FoodItem> lstFoodItems = new List<FoodItem>();

            // Act
            var result = (ViewResult)controller.AddMeal(Models.MealType.Breakfast, lstFoodItems, 3, 5);

            // Assert
            
        }

    }
}
