using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wholewellness.Models;

namespace wholewellness.DAL
{
    public class MealDAL
    {
        private static Meal GetMealFromDR(NpgsqlDataReader dr)
        {
            int intMealID = Convert.ToInt32(dr["intMealID"]);
            MealType mealType = (MealType)Enum.Parse(typeof(MealType), dr["mealType"].ToString());
            int intUserID = Convert.ToInt32(dr["intUserID"]);
            List<FoodItem> lstContents = FoodItemDAL.GetFoodByMealAndUser(intMealID, intUserID);

            Meal meal = Meal.of(intMealID, mealType, lstContents);

            return meal;
        }

        public static List<Meal> GetMealsByDayAndUser(int intDayID, int intUserID)
        {
            List<Meal> retval = new List<Meal>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT me.\"intMealID\", me.\"mealType\", me.\"intUserID\" FROM meal as me, \"dayMeal\" as dm, \"day\" as d" +
                " WHERE me.\"intMealID\" = dm.\"intMealID\"" +
                " AND d.\"intDayID\" = dm.\"intDayID\"" +
                " AND d.\"intDayID\" = " + intDayID +
                " AND me.\"intUserID\" = " + intUserID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                Meal meal = GetMealFromDR(dr);
                retval.Add(meal);
            }

            conn.Close();

            return retval;
        }

        public static bool AddMeal(Meal meal, int intUserID, int intDayID)
        {

            // insert into meal table
            int intNewMealID = MealDAL.InsertToMealTable(meal, intUserID);

            meal.intMealID = intNewMealID;

            // insert into foodMeal table with newly created meal ID & list of food
            // insert each item to food meal table

            foreach (var foodItem in meal.lstContents)
            {
                MealDAL.InsertToFoodMealTable(meal.intMealID, foodItem.intFoodItemID);
            }

            // insert into dayMeal table with newly created meal ID
            bool dayMealSuccess = MealDAL.InsertToDayMealTable(intNewMealID, intDayID);

            // subtract cals fron that day's cals left for that user
            bool subtractCalsSuccess = MealDAL.SubtractCals(meal.lstContents, intUserID, intDayID);

            //NpgsqlConnection conn = DatabaseConnection.GetConnection();
            //conn.Open();

            //// define a query
            //string query = "";
            //NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("");

            //int result = cmd.ExecuteNonQuery();

            //conn.Close();


            //if (result == 1)
            //    return true;
            //else
            //    return false;

            return dayMealSuccess && subtractCalsSuccess;
        }

        private static bool InsertToDayMealTable(int intNewMealID, int intDayID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"dayMeal\"" +
                " (\"intDayID\", \"intMealID\")" +
                " VALUES" +
                " (@intDayID, @intMealID)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intDayID", intDayID);
            cmd.Parameters.AddWithValue("intMealID", intNewMealID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }

        private static bool InsertToFoodMealTable(int intMealID, int intFoodItemID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"foodMeal\"" +
                " (\"intMealID\", \"intFoodItemID\")" +
                " VALUES" +
                " (@intMealID, @intFoodItemID)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("intMealID", intMealID);
            cmd.Parameters.AddWithValue("intFoodItemID", intFoodItemID);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }

        private static int InsertToMealTable(Meal meal, int intUserID)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO \"meal\"" +
                " (\"mealType\", \"intUserID\")" +
                " VALUES" +
                " ('" + meal.mealType.ToString() + "', @intUserID)" +
                " RETURNING \"intMealID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("mealType", meal.mealType.ToString());
            cmd.Parameters.AddWithValue("intUserID", intUserID);

            int result = (int)cmd.ExecuteScalar();

            conn.Close();

            return result;
        }

        private static bool SubtractCals(List<FoodItem> lstContents, int intUserID, int intDayID)
        {
            int totalCalsToSubtract = 0;

            foreach (var foodItem in lstContents)
            {
                totalCalsToSubtract += foodItem.intCalories;
            }

            int originalCals = DayDAL.GetCalsLeftByDayAndUser(intUserID, intDayID);

            int updateValue = originalCals - totalCalsToSubtract;
            
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
    }
}