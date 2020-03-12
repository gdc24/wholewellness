using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        // addMeal(Meal meal)
        public void addMeal(Meal meal)
        {
          // Day.this.mealsAdded.add(meal);
        }

        // deleteMeal(Meal meal)
        public void deleteMeal(Meal meal)
        {
            // Day.this.mealsAdded.remove(meal);
        }

        // addExercise(WorkoutRoutine routine)
        public void addExercise(WorkoutRoutine routine)
        {
            // Day.this.exerciseCompleted.add(routine);
        }

        // deleteExercise(WorkoutRoutine routine)
        public void removeExercise(WorkoutRoutine routine)
        {
            // Day.this.exerciseCompleted.remove(routine)
        }

        // getHistory()
        public List<Day> getHistory()
        {
            // return User.this.history;
            return new List<Day>();
        }

        // getUserInfo(String username)


        // getAllWorkouts() - is this meant to get all that the user has done in a day or all that there are in the database?

        // getAllFoodItems() - is this meant to get all that the user has eaten in a day or all that there are in the database?


    }
}
