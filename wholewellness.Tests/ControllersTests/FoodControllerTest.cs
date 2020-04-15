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
        public void FoodHome()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = controller.FoodHome();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddMeal()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result =  controller.AddMeal();

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
            var result = = controller.DeleteMeal(meal, 3, 5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetHistory()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result =  controller.GetHistory(5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUserInfo()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = controller.GetUserInfo(5);

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public void GetAllFoodItems()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result = controller.GetAllFoodItems();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HealthierOptions()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result =  controller.HealthierOptions();

            // Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void GetHealthierOptions()
        {
            // Arrange
            var controller = new FoodController();

            // Act
            var result =  controller.GetHealthierOptions(2);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
