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
            var result = controller.WorkoutHome();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddExercise()
        {
            // Act
            var controller = new WorkoutController();

            // Arrange
            var result = controller.AddWorkout();
        }

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        // TODO: Test fails, think something is wrong in DAL
        [Test]
        public void DeleteWorkout()
        {
            // Act
            var controller = new WorkoutController();
            List<ExerciseType> lstExercises = new List<ExerciseType>();
            WorkoutRoutine workout = WorkoutRoutine.of(10, lstExercises, 100);

            // Arrange
            var result = controller.DeleteWorkout(workout, 5, 5);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
