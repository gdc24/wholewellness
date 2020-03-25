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
            List<FoodItem> retval = null;

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT fi.\"intFoodItemID\", fi.\"strName\", fi.\"intCalories\", fi.\"strBrandName\", FROM foodItem fi, foodMeal fm, meal m" +
                " WHERE m.\"intUserID\" = " + intUserID +
                " AND fm.\"intMealID\" = " + intMealID +
                " AND fm.\"intFoodItemID\" = fi.\"intFoodItemID\"" +
                " AND fm.\"intMealID\" = m.\"intMealID\"";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                FoodItem foodItem = GetFoodItemFromDR(dr);
                retval.Append(foodItem);
            }

            conn.Close();

            return retval;
        }
    }
}