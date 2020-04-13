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
            List<Meal> lstMealsAdded = MealDAL.GetMealsByDayAndUser(intDayID, intUserID).ToList();
            List<WorkoutRoutine> lstWorkoutRoutines = null; // WorkoutRoutineDAL.GetExercisesByDayAndUser(intDayID, intUserID);

            Day day = Day.of(intDayID, lstMealsAdded, dtmDate, lstWorkoutRoutines, intCalsLeft);

            return day;
        }

        public static List<Day> GetDaysByUser(int intUserID)
        {
            List<Day> retval = new List<Day>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT * FROM \"day\" WHERE \"intUserID\" = " + intUserID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                Day day = GetDayFromDR(dr);
                retval.Add(day);
            }

            conn.Close();

            return retval;
        }

        public static Day GetDayByUserAndDay(int intUserID)
        {
            Day retval = null;

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string dtmDate = DateTime.Today.ToString("yyyy-MM-dd");

            // define a query
            string query = "SELECT * FROM \"day\" WHERE \"intUserID\" = " + intUserID +
                " AND CAST(\"dtmDate\" AS DATE) = '" + dtmDate + "'";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                retval = GetDayFromDR(dr);
            }

            conn.Close();

            int success = 1;
            if (retval == null)
            {
                success = InsertDayForUser(intUserID);
                retval = GetDayByUserAndDay(intUserID);
            }
            if (success != 0)
                return retval;
            else
                throw new Exception("current day could not be created");
        }

        private static int InsertDayForUser(int intUserID)
        {

            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO public.day(" +
                " \"dtmDate\", \"intCalsLeft\", \"intUserID\")" +
                " VALUES((select(current_date at time zone '-4')::date), (SELECT \"intAllotedCalories\" FROM \"user\" WHERE \"intUserID\" = " + intUserID + "), " + intUserID + ");";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("intUserID1", intUserID);
            //cmd.Parameters.AddWithValue("intUserID2", intUserID);

            int result = (int)cmd.ExecuteNonQuery();

            conn.Close();

            return result;
        }

        internal static int GetCalsLeftByDayAndUser(int intUserID, int intDayID)
        {
            Day day = null;

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string dtmDate = DateTime.Today.ToString("yyyy-MM-dd");

            // define a query
            string query = "SELECT * FROM \"day\" WHERE \"intUserID\" = " + intUserID +
                " AND \"intDayID\" = " + intDayID;

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                day = GetDayFromDR(dr);
            }

            conn.Close();

            return day.intCalsLeft;
        }
    }
}