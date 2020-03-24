using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.DAL
{
    public class DayDAL
    {
        private static Day GetDayFromDR(NpgsqlDataReader dr)
        {
            int intDayID = Convert.ToInt32(dr["intDayID"]);
            DateTime dtmDate = (DateTime)dr["dtmDate"];
            int intCalsLeft = Convert.ToInt32(dr["intCalsLeft"]);
            int intUserID = Convert.ToInt32(dr["intUserID"]);
            List<Meal> lstMealsAdded = MealDAL.GetMealsByDayAndUser(intDayID, intUserID);
            List<WorkoutRoutine> lstWorkoutRoutines = WorkoutRoutinesDAL.GetExercisesByDayAndUser(intDayID, intUserID);

            Day day = Day.of(lstMealsAdded, dtmDate, lstWorkoutRoutines, intCalsLeft);

            return day;
        }

        public static IEnumerable<Day> GetDaysByUser(int intUserID)
        {
            return null;
        }
    }
}