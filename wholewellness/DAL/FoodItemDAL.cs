using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.DAL
{
    public class FoodItemDAL
    {
        private static FoodItem GetFoodItemFromDR(NpgsqlDataReader dr)
        {
            int intFoodItemID = Convert.ToInt32(dr["intFoodItemID"]);
            string strName = dr["strName"].ToString();
            int intCalories = Convert.ToInt32(dr["intCalories"]);
            string strBrandName = dr["strBrandName"].ToString();

            FoodItem foodItem = FoodItem.of(intFoodItemID, strName, intCalories, strBrandName);

            return foodItem;
        }

        public static List<FoodItem> GetFoodByMealAndUser(int intMealID, int intUserID)
        {
            List<FoodItem> retval = new List<FoodItem>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT fi.\"intFoodItemID\", fi.\"strName\", fi.\"intCalories\", fi.\"strBrandName\"" +
                " FROM \"foodItem\" fi, \"foodMeal\" fm, \"meal\" me" +
                " WHERE me.\"intUserID\" = " + intUserID +
                " AND fm.\"intMealID\" = " + intMealID +
                " AND fm.\"intFoodItemID\" = fi.\"intFoodItemID\"" +
                " AND fm.\"intMealID\" = me.\"intMealID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                FoodItem foodItem = GetFoodItemFromDR(dr);
                retval.Add(foodItem);
            }

            conn.Close();

            return retval;
        }

        internal static List<FoodItem> GetHealthyAlternatives(int intFoodItemID)
        {
            List<FoodItem> retval = new List<FoodItem>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT fi.\"intFoodItemID\", fi.\"strName\", fi.\"intCalories\", fi.\"strBrandName\"" +
                " FROM \"healthierOptions\" ho, \"foodItem\" fi" +
                " WHERE ho.\"intAlternativeFoodItemID\" = fi.\"intFoodItemID\"" +
                " AND ho.\"intOriginalFoodItemID\" = " + intFoodItemID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                FoodItem foodItem = GetFoodItemFromDR(dr);
                retval.Add(foodItem);
            }

            conn.Close();

            return retval;

        }

        public static FoodItem GetFoodItemByID(int intFoodItemID)
        {
            FoodItem retval = null;

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT * FROM \"foodItem\" WHERE \"intFoodItemID\" = " + intFoodItemID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                retval = GetFoodItemFromDR(dr);
            }

            conn.Close();

            return retval;
        }

        public static List<FoodItem> GetFoodItemsByIDs(int[] arrFoodItemIDs)
        {
            List<FoodItem> retval = new List<FoodItem>();

            foreach (int id in arrFoodItemIDs)
            {
                FoodItem tmpFoodItem = GetFoodItemByID(id);
                retval.Add(tmpFoodItem);
            }

            return retval;
        }

        public static List<FoodItem> GetAllFoodItems()
        {
            List<FoodItem> retval = new List<FoodItem>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT * FROM \"foodItem\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                FoodItem foodItem = GetFoodItemFromDR(dr);
                retval.Add(foodItem);
            }

            conn.Close();

            return retval;
        }
    }
}