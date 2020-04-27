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
                    LstWorkoutRoutines = WorkoutRoutineDAL.GetWorkoutsByDayAndUser(day.intDayID, user.intUserID)
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
                return RedirectToAction("AddExerciseType");
            else
                throw new Exception("error adding exercise type");
        }


        // TODO: finish
        public ActionResult AddWorkout()
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
                    intPassedUserID = user.intUserID
                };

                model._results_vm.possibleExercises = new List<ExerciseType>();
                bool hasAny = model._results_vm.possibleExercises.Any();

                return View(model);
            }
        }

        public ActionResult SearchForExercises(MuscleGroup muscleGroup)
        {
            ExerciseType searchCriteria = new ExerciseType
            {
                muscleGroup = muscleGroup
            };
            //if (muscleGroup != null)
            //    searchCriteria.muscleGroup = (MuscleGroup)muscleGroup;
            //if (equipment != null)
            //    searchCriteria.equipment = (Equipment)equipment;
            //if (intensity != null)
            //    searchCriteria.intensity = (Intensity)intensity;
            //if (ysnAccessibility != null)
            //    searchCriteria.ysnAccessibility = (bool)ysnAccessibility;

            ExerciseResultsVM model = new ExerciseResultsVM
            {
                possibleExercises = ExerciseTypeDAL.GetSearchResults(searchCriteria)
            };

            if (!model.possibleExercises.Any())
                model.strSearchMessage = "No results for that search. Please select another.";

            return PartialView("_ExerciseSearchResults", model);
        }

        public ActionResult FilterExercises(MuscleGroup muscleGroup, Equipment equipment, Intensity intensity, bool ysnAccessibility)
        {
            ExerciseType searchCriteria = new ExerciseType()
            {
                muscleGroup = muscleGroup,
                equipment = equipment,
                intensity = intensity,
                ysnAccessibility = ysnAccessibility
            };

            ExerciseResultsVM model = new ExerciseResultsVM
            {
                possibleExercises = ExerciseTypeDAL.GetFilterResults(searchCriteria)
            };

            if (!model.possibleExercises.Any())
                model.strSearchMessage = "No results for that filter. Please select another.";

            return PartialView("_ExerciseSearchResults", model);
        }

        [HttpPost]
        public ActionResult PostNewWorkout(int[] arrIntExerciseTypeIDs)
        {
            bool success = WorkoutRoutineDAL.AddWorkoutRoutine(arrIntExerciseTypeIDs);

            if (success)
                return Json(Url.Action("Index", "Workout"));
            else
                throw new Exception("error adding workout");
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
