using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.DAL
{
    public class ExerciseTypeDAL
    {
        private static ExerciseType GetExerciseFromDR(NpgsqlDataReader dr)
        {
            int intExerciseTypeID = Convert.ToInt32(dr["intExerciseTypeID"]);
            string strName = dr["strName"].ToString();
            int intCaloriesBurned = Convert.ToInt32(dr["intCaloriesBurned"]);
            bool ysnAccessibility = Convert.ToBoolean(dr["ysnAccessibility"]);
            List<MuscleGroup> lstMuscleGroups = GetMuscleGroupList(intExerciseTypeID);
            Intensity intensity = GetIntensity(dr["intensity"]); //(Intensity)Enum.Parse(typeof(Intensity), dr["intensity"].ToString());
            int intTime = Convert.ToInt32(dr["intTime"]);

            ExerciseType foodItem = ExerciseType.of(lstMuscleGroups, strName, intCaloriesBurned, ysnAccessibility, intensity, intTime);

            return foodItem;
        }

        private static Intensity GetIntensity(object fromDB)
        {
            string strIntensity = fromDB.ToString();
            Intensity retval = 0;
            switch (strIntensity)
            {
                case "low":
                    retval = Intensity.Low;
                    break;
                case "med":
                    retval = Intensity.Medium;
                    break;
                case "high":
                    retval = Intensity.High;
                    break;

            }

            return retval;
        }

        private static List<MuscleGroup> GetMuscleGroupList(int intExerciseTypeID)
        {
            throw new NotImplementedException();
        }
    }
}