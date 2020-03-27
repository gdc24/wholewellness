using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

using wholewellness.Controllers;
using wholewellness.Models;

namespace wholewellness.Tests.Controllers
{
    [TestFixture]
    public class FoodControllerTest
    {
        
        [Test]
        public void AddMeal()
        {
            // Arrange
            var controller = new FoodController();
            List<FoodItem> lstFoodItems = new List<FoodItem>();

            // Act
            var result = (ViewResult)controller.AddMeal(MealType.breakfast, lstFoodItems, 3, 5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteMeal()
        {
            // Arrange
            var controller = new FoodController();
            List<FoodItem> lstFoodItems = new List<FoodItem>();
            Meal meal = Meal.of(MealType.breakfast, lstFoodItems);

            // Act
            var result = (ViewResult)controller.DeleteMeal(meal, 3, 5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetHistory()
        {
            // Arrange
            var controller = new FoodController();
            List<FoodItem> lstFoodItems = new List<FoodItem>();

            // Act
            var result = (ViewResult)controller.GetHistory(5);

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
