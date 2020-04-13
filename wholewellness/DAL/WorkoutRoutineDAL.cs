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

        public static bool AddWorkoutRoutine(WorkoutRoutine workout, int intUserID, int intDayID)
        {
            // insert into meal table
            int intNewWorkoutID = WorkoutRoutineDAL.InsertToWorkoutTable(workout, intUserID);

            workout.intWorkoutRoutineID = intNewWorkoutID;

            // insert into workoutExerciseType table with newly created workout & list of exercises
            // insert each exercise to workout exercise table

            foreach (ExerciseType exercise in workout.lstRoutine)
            {
                WorkoutRoutineDAL.InsertToWorkoutExerciseTypeTable(workout.intWorkoutRoutineID, exercise.intExerciseTypeID);
            }

            // insert into dayExercise table with newly created workout ID
            bool dayExerciseSuccess = WorkoutRoutineDAL.InsertToDayExerciseTable(intNewWorkoutID, intDayID);

            // add cals to that day's cals left for that user
            bool addCalsSuccess = WorkoutRoutineDAL.AddCals(workout, intUserID, intDayID);

            //NpgsqlConnection conn = DatabaseConnection.GetConnection();
            //conn.Open();

            //// define a query
            //string query = "";
            //NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("");

            //int result = cmd.ExecuteNonQuery();

            //conn.Close();

            return dayExerciseSuccess && addCalsSuccess;
        }

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

        public static int InsertToWorkoutTable(WorkoutRoutine workout, int intUserID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"workoutRoutine\"" +
                " (\"intTotalMinutes\", \"intTotalCalsBurned\", \"intUserID\")" +
                " VALUES" +
                " (@intTotalMinutes, @intTotalCalsBurned, @intUserID)" +
                " RETURNING \"intMealID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intTotalMinutes", workout.intTotalMinutes);
            cmd.Parameters.AddWithValue("intTotalCalsBurned", workout.intTotalCalsBurned);
            cmd.Parameters.AddWithValue("intUserID", intUserID);

            int result = (int)cmd.ExecuteScalar();

            conn.Close();

            return result;
        }

        public static bool AddCals(WorkoutRoutine workout, int intUserID, int intDayID)
        {
            //TODO
            throw new NotImplementedException();
        }

    }
}