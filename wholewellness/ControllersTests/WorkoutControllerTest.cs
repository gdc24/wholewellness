using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

using wholewellness.Controllers;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.ControllersTests
{
    [TestFixture]
    public class WorkoutControllerTest
    {
        [Test]
        public void WorkoutHome()
        {
            // Act
            var controller = new WorkoutController();

            // Arrange
            var result = (ViewResult)controller.WorkoutHome();

            // Assert
            Assert.IsNotNull(result);
        }

        // TODO: test fails
        [Test]
        public void AddExercise()
        {
            // Act
            var controller = new WorkoutController();

            // Arrange
            var result = (ViewResult)controller.AddExercise();

            // Assert
            Assert.IsNotNull(result);
        }

        // TODO: test fails
        [Test]
        public void DeleteWorkout()
        {
            // Act
            var controller = new WorkoutController();
            List<ExerciseType> lstExercises = new List<ExerciseType>();
            WorkoutRoutine workout = WorkoutRoutine.of(10, lstExercises, 100);

            // Arrange
            var result = (ViewResult)controller.DeleteWorkout(workout, 5, 5);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllWorkouts()
        {
            // Act
            var controller = new WorkoutController();

            // Arrange
            var result = (ViewResult)controller.GetAllWorkouts();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
