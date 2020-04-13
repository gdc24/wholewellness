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
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);
            Day day = DayDAL.GetDayByUserAndDay(user.intUserID);

            ExerciseVM model = new ExerciseVM()
            {
                user = user,

            };
            return View("WorkoutHome", model);
        }

        public ActionResult AddExerciseType()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);

            AddExerciseTypeVM model = new AddExerciseTypeVM()
            {
                user = user
            };
            return View(model);
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

        public ActionResult DeleteWorkout(WorkoutRoutine workout, int intDayID, int intUserID)
        {
            ExerciseVM model = new ExerciseVM()
            {
                LstWorkoutRoutines = WorkoutRoutineDAL.GetWorkoutsByDayAndUser(intDayID, intUserID).Where(w => w != workout)
            };
            return View("WorkoutHome", model);
        }


        // TODO: finish
        public ActionResult GetAllWorkouts()
        {
            AddWorkoutVM model = new AddWorkoutVM()
            {
                // possibleExercises = WorkoutRoutineDAL.GetAllPossibleExercises
            };
            return View("WorkoutHome", model);
        }
    }
}
