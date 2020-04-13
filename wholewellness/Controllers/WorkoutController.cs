using System.Linq;
using wholewellness.DAL;
using wholewellness.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.ViewModels;
using wholewellness.Models.ExerciseTrackingModels;

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
            if (HomeController.USER_NUMBER == -1)
            {
                return RedirectToAction("NewUser", "Home");
            }
            else
            {
                User user = UserDAL.GetUser(HomeController.USER_NUMBER);
                Day day = DayDAL.GetDayByUserAndDay(user.intUserID);

                WorkoutHomeVM model = new WorkoutHomeVM()
                {
                    user = user,

                };
                return View(model);
            }            
        }

        public ActionResult AddExerciseType()
        {
            if (HomeController.USER_NUMBER == -1)
            {
                return RedirectToAction("NewUser", "Home");
            }
            else
            {
                User user = UserDAL.GetUser(HomeController.USER_NUMBER);

                AddExerciseTypeVM model = new AddExerciseTypeVM()
                {
                    user = user
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult PostNewExerciseType(ExerciseType newExercise)
        {
            bool success = ExerciseTypeDAL.AddExerciseType(newExercise);

            if (success)
                return RedirectToAction("AddExercise");
            else
                throw new Exception("error adding food item");
        }

        public ActionResult AddExercise()
        {
            if (HomeController.USER_NUMBER == -1)
            {
                return RedirectToAction("NewUser", "Home");
            }
            else
            {
                User user = UserDAL.GetUser(HomeController.USER_NUMBER);
                Day currentDay = DayDAL.GetDayByUserAndDay(user.intUserID);

                AddWorkoutVM model = new AddWorkoutVM
                {
                    user = user,
                    currentDayForUser = currentDay,
                    intPassedCurrentDayID = currentDay.intDayID,
                    intPassedUserID = user.intUserID,
                    possibleWorkouts = WorkoutRoutineDAL.GetWorkoutsByDayAndUser(currentDay.intDayID,user.intUserID)
                };

                return View(model);
            }
        }

        public ActionResult DeleteWorkout(WorkoutRoutine workout, int intDayID, int intUserID)
        {
            WorkoutHomeVM model = new WorkoutHomeVM()
            {
                LstWorkoutRoutines = WorkoutRoutineDAL.GetWorkoutsByDayAndUser(intDayID, intUserID).Where(w => w != workout)
            };
            return View("WorkoutHome", model);
        }
    }
}
