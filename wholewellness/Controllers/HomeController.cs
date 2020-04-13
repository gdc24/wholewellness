using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.Models;
using wholewellness.DAL;
using System.Linq;
using wholewellness.ViewModels;

namespace wholewellness.Controllers
{
    public class HomeController : Controller
    {

        //public static int USER_NUMBER = -1; // FOR PROD
        //public static int DAY_NUMBER = -1; // FOR PROD
        public static int USER_NUMBER = 1; // FOR DEV
        public static int DAY_NUMBER = 9324; // FOR DEV
        private readonly static int NUM_PREVIEWS = 3;

        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            if (USER_NUMBER == -1)
            {
                return RedirectToAction("NewUser");
            }
            else
            {
                Day currentDayForUser = DayDAL.GetDayByUserAndDay(USER_NUMBER);
                User user = UserDAL.GetUser(USER_NUMBER);

                USER_NUMBER = user.intUserID;
                DAY_NUMBER = currentDayForUser.intDayID;

                HomeVM model = new HomeVM
                {
                    user = user,
                    intCalsLeft = currentDayForUser.intCalsLeft,
                    intExMinsLeft = currentDayForUser.intExMinsLeft,
                    mostRecentMeals = MealDAL.GetMealsByDayAndUser(currentDayForUser.intDayID, user.intUserID).Take(NUM_PREVIEWS).ToList()
                };
                return View(model);
            }

        }

        public ActionResult NewUser()
        {
            NewUserVM model = new NewUserVM();

            return View("NewUser", model);
        }

        [HttpPost]
        public ActionResult AddUser(User newUser)
        {
            switch (newUser.exerciseLevel)
            {
                case ExerciseLevel.LowIntensity:
                    newUser.intAllotedExerciseMinutes = 120;
                    break;
                case ExerciseLevel.MediumIntensity:
                    newUser.intAllotedExerciseMinutes = 90;
                    break;
                case ExerciseLevel.HighIntensity:
                    newUser.intAllotedExerciseMinutes = 60;
                    break;
            }

            newUser.intAllotedCalories = CalculateCalories(newUser.intWeight, newUser.intHeightInInches, 22, newUser.exerciseLevel);

            bool success = UserDAL.InsertUser(newUser);

            if (success)
            {
                User user = UserDAL.GetUserByUsername(newUser.strUsername);
                //USER_NUMBER = user.intUserID;

                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception("There was an error inserting a new user. Please try again.");
            }
            
        }

        private int CalculateCalories(int intWeight, int intHeightInInches, int intAge, ExerciseLevel exerciseLevel)
        {
            double BMR = 655 + (4.3 * intWeight) + (4.7 * intHeightInInches) - (4.7 * intAge);

            switch (exerciseLevel)
            {
                case ExerciseLevel.LowIntensity:
                    BMR *= 1.375;
                    break;
                case ExerciseLevel.MediumIntensity:
                    BMR *= 1.55;
                    break;
                case ExerciseLevel.HighIntensity:
                    BMR *= 1.725;
                    break;
            }

            return (int)BMR;
        }

        public ActionResult Login(string strUsername)
        {
            User user = UserDAL.GetUserByUsername(strUsername);
            //USER_NUMBER = user.intUserID;

            return RedirectToAction("Index");
        }
    }
}
