using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Controllers;
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
            List<ExerciseType> lstRoutine = ExerciseTypeDAL.GetExercisesByWorkout(intWorkoutRoutineID).ToList();

            WorkoutRoutine workoutRoutine = WorkoutRoutine.of(intWorkoutRoutineID, intTotalMinutes, lstRoutine, intTotalCalsBurned);

            return workoutRoutine;
        }

        public static List<WorkoutRoutine> GetWorkoutsByDayAndUser(int intDayID, int intUserID)
        {
            List<WorkoutRoutine> retval = new List<WorkoutRoutine>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT wr.\"intWorkoutRoutineID\"," +
                " wr.\"intTotalMinutes\"," +
                " wr.\"intTotalCalsBurned\"," +
                " wr.\"intUserID\"" +
                " FROM \"workoutRoutine\" wr, \"day\" d, \"dayExercise\" de" +
                " WHERE wr.\"intUserID\" = " + intUserID +
                " AND d.\"intDayID\" = " + intDayID +
                " AND de.\"intDayID\" = d.\"intDayID\"" +
                " AND wr.\"intWorkoutRoutineID\" = de.\"intWorkoutRoutineID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                WorkoutRoutine workout = GetWorkoutRoutineFromDR(dr);
                retval.Add(workout);
            }

            conn.Close();

            return retval;
        }

        //public static bool AddWorkoutRoutine(WorkoutRoutine workout, int intUserID, int intDayID)
        //{
        //    // insert into meal table
        //    int intNewWorkoutID = WorkoutRoutineDAL.InsertToWorkoutTable(workout, intUserID);

        //    workout.intWorkoutRoutineID = intNewWorkoutID;

        //    // insert into workoutExerciseType table with newly created workout & list of exercises
        //    // insert each exercise to workout exercise table

        //    foreach (ExerciseType exercise in workout.lstRoutine)
        //    {
        //        WorkoutRoutineDAL.InsertToWorkoutExerciseTypeTable(workout.intWorkoutRoutineID, exercise.intExerciseTypeID);
        //    }

        //    // insert into dayExercise table with newly created workout ID
        //    bool dayExerciseSuccess = WorkoutRoutineDAL.InsertToDayExerciseTable(intNewWorkoutID, intDayID);

        //    // add cals to that day's cals left for that user
        //    bool addCalsSuccess = WorkoutRoutineDAL.AddCals(workout, intUserID, intDayID);

        //    return dayExerciseSuccess && addCalsSuccess;
        //}

        public static bool InsertToDayExerciseTable(int intNewWorkoutID, int intDayID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"dayExercise\"" +
                " (\"intDayID\", \"intWorkoutRoutineID\")" +
                " VALUES" +
                " (@intDayID, @intWorkoutRoutineID)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intDayID", intDayID);
            cmd.Parameters.AddWithValue("intWorkoutRoutineID", intNewWorkoutID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }

        public static bool InsertToWorkoutExerciseTypeTable(int intWorkoutRoutineID, int intExerciseTypeID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"workoutExerciseType\"" +
                " (\"intExerciseTypeID\", \"intWorkoutRoutineID\")" +
                " VALUES" +
                " (@intExerciseTypeID, @intWorkoutRoutineID)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intExerciseTypeID", intExerciseTypeID);
            cmd.Parameters.AddWithValue("intWorkoutRoutineID", intWorkoutRoutineID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }

        internal static bool AddWorkoutRoutine(int[] arrIntExerciseTypeIDs)
        {
            int intUserID = HomeController.USER_NUMBER;
            int intDayID = HomeController.DAY_NUMBER;
            // calculate total minutes and total calories burned
            List<ExerciseType> exercises = new List<ExerciseType>();
            ExerciseType tmpExercise;
            foreach (int id in arrIntExerciseTypeIDs)
            {
                tmpExercise = ExerciseTypeDAL.GetExerciseTypeByID(id);
                exercises.Add(tmpExercise);
            }

            int intTotalMinutes = 0;
            int intTotalCalsBurned = 0;
            foreach (ExerciseType ex in exercises)
            {
                intTotalMinutes += ex.intTime;
                intTotalCalsBurned += ex.intCaloriesBurned;
            }

            WorkoutRoutine workoutRoutine = WorkoutRoutine.of(intTotalMinutes, exercises, intTotalCalsBurned);

            // insert to workout table
            // get the id of new workout
            int intWorkoutRoutineID = InsertToWorkoutTable(workoutRoutine, intUserID);

            bool success = false;
            // insert each id in array to workoutExerciseType table
            foreach (ExerciseType ex in exercises)
            {
                success = InsertToWorkoutExerciseTypeTable(intWorkoutRoutineID, ex.intExerciseTypeID);
            }

            // remove time from alloted exercise minutes
            bool exMinsSuccess = RemoveTime(intTotalMinutes, intUserID, intDayID);

            // add calories to users' calories for the day
            bool calsSuccess = AddCals(workoutRoutine.intTotalCalsBurned, intUserID, intDayID);

            return success && exMinsSuccess && calsSuccess;
        }

        public static int InsertToWorkoutTable(WorkoutRoutine workout, int intUserID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"workoutRoutine\"" +
                " (\"intTotalMinutes\", \"intTotalCalsBurned\", \"intUserID\")" +
                " VALUES" +
                " (@intTotalMinutes, @intTotalCalsBurned, @intUserID)" +
                " RETURNING \"intWorkoutRoutineID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intTotalMinutes", workout.intTotalMinutes);
            cmd.Parameters.AddWithValue("intTotalCalsBurned", workout.intTotalCalsBurned);
            cmd.Parameters.AddWithValue("intUserID", intUserID);

            int result = (int)cmd.ExecuteScalar();

            conn.Close();

            return result;
        }

        public static bool AddCals(int intTotalCalsToAdd, int intUserID, int intDayID)
        {

            int originalCals = DayDAL.GetCalsLeftByDayAndUser(intUserID, intDayID);

            int updateValue = originalCals + intTotalCalsToAdd;

            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "UPDATE \"day\"" +
                " SET \"intCalsLeft\" = @updateValue" +
                " WHERE \"intUserID\" = @intUserID" +
                " AND \"intDayID\" = @intDayID";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("updateValue", updateValue);
            cmd.Parameters.AddWithValue("intUserID", intUserID);
            cmd.Parameters.AddWithValue("intDayID", intDayID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;

        }

        public static bool RemoveTime(int intTotalMinsToSubtract, int intUserID, int intDayID)
        {
            int exerciseLeft = DayDAL.GetExerciseLeftByDayAndUser(intUserID, intDayID);

            int updateValue = exerciseLeft - intTotalMinsToSubtract;

            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "UPDATE \"day\"" +
                " SET \"intExMinsLeft\" = @updateValue" +
                " WHERE \"intUserID\" = @intUserID" +
                " AND \"intDayID\" = @intDayID";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("updateValue", updateValue);
            cmd.Parameters.AddWithValue("intUserID", intUserID);
            cmd.Parameters.AddWithValue("intDayID", intDayID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }
    }
}