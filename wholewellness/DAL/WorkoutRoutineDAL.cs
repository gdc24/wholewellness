using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.DAL
{
    public class WorkoutRoutineDAL
    {

        private static WorkoutRoutine GetWorkoutRoutineFromDR(NpgsqlDataReader dr)
        {
            int intWorkoutRoutineID = Convert.ToInt32(dr["intWorkoutRoutineID"]);
            int intTotalMinutes = Convert.ToInt32(dr["intTotalMinutes"]);
            int intTotalCalsBurned = Convert.ToInt32(dr["intTotalCalsBurned"]);
            int intUserID = Convert.ToInt32(dr["intUserID"]);
            List<ExerciseType> lstRoutine = null; //ExerciseTypeDAL.GetExercisesByWorkout(intWorkoutRoutineID).ToList();

            WorkoutRoutine workoutRoutine = WorkoutRoutine.of(intTotalMinutes, lstRoutine, intTotalCalsBurned);

            return workoutRoutine;
        }

        public static List<WorkoutRoutine> GetExercisesByDayAndUser(int intDayID, int intUserID)
        {
            throw new NotImplementedException();
        }
    }
}