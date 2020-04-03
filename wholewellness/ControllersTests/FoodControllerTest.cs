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

        // TODO: test fails
        [Test]
        public void FoodHome()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = (ViewResult)controller.FoodHome();

            // Assert
            Assert.IsNotNull(result);
        }

        // TODO: test fails
        [Test]
        public void AddMeal()
        {
            // Arrange
            var controller = new FoodController();
            int[] arrFoodItems = new int[10];

            // Act
            var result = (ViewResult)controller.PostNewMeal(MealType.breakfast, arrFoodItems, 3, 5);

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

            // Act
            var result = (ViewResult)controller.GetHistory(5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUserInfo()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = (ViewResult)controller.GetUserInfo(5);

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public void GetAllFoodItems()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = (ViewResult)controller.GetAllFoodItems();

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
