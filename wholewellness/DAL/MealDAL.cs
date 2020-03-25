using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.DAL
{
    public class MealDAL
    {
        private static Meal GetDayFromDR(NpgsqlDataReader dr)
        {
            int intMealID = Convert.ToInt32(dr["intMealID"]);
            MealType mealType = (MealType)Enum.Parse(typeof(MealType), dr["mealType"].ToString());
            int intUserID = Convert.ToInt32(dr["intUserID"]);
            List<FoodItem> lstContents = FoodItemDAL.GetFoodByMealAndUser(intMealID, intUserID);

            Meal meal = Meal.of(mealType, lstContents);

            return meal;
        }

        public static IEnumerable<Meal> GetMealsByDayAndUser(int intDayID, int intUserID)
        {
            IEnumerable<Meal> retval = null;

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT * FROM meal WHERE \"intUserID\" = " + intUserID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                Meal meal = GetDayFromDR(dr);
                retval.Append(meal);
            }

            conn.Close();

            return retval;
        }


    }
}