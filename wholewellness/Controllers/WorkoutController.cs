using System.Linq;
using wholewellness.DAL;
using wholewellness.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.ViewModels;

namespace wholewellness.Controllers
{
    public class WorkoutController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("WorkoutHome");
        }

        public ActionResult WorkoutHome()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);
            Day day = DayDAL.GetDayByUserAndDay(user.intUserID);

            ExerciseVM model = new ExerciseVM()
            {
                user = user,

            };
            return View("WorkoutHome", model);
        }


        // TODO: finish
        public ActionResult AddExercise()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);
            Day currentDay = DayDAL.GetDayByUserAndDay(user.intUserID);

            AddWorkoutVM model = new AddWorkoutVM
            {
                user = user,
                currentDayForUser = currentDay,
               // possibleExercises = WorkoutRoutineDAL.GetAllPossibleExercises,
                intPassedCurrentDayID = currentDay.intDayID,
                intPassedUserID = user.intUserID
            };

            return View(model);
        }

        // TODO: deleteExercise


        // TODO: GetAllWorkouts
    }
}
