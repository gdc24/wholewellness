using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using wholewellness.DAL;
using wholewellness.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserDAL
{
    private static User GetUserFromDR(NpgsqlDataReader dr)
    {
        int intUserID = Convert.ToInt32(dr["intUserID"]);
        string strUsername = dr["strUsername"].ToString();
        int intWeight = Convert.ToInt32(dr["intWeight"]);
        int intHeightInInches = Convert.ToInt32(dr["intHeightInInches"]);
        string strExerciseLevel = dr["exerciseLevel"].ToString();
        ExerciseLevel exerciseLevel = ExerciseLevel.LowIntensity;
        switch (strExerciseLevel)
        {
            case "low":
                exerciseLevel = ExerciseLevel.LowIntensity;
                break;
            case "med":
                exerciseLevel = ExerciseLevel.MediumIntensity;
                break;
            case "high":
                exerciseLevel = ExerciseLevel.HighIntensity;
                break;
        }
        //ExerciseLevel exerciseLevel = (ExerciseLevel)Enum.Parse(typeof(ExerciseLevel), strExerciseLevel, true);
        int intAllotedCalories = Convert.ToInt32(dr["intAllotedCalories"]);
        int intAllotedExerciseMinutes = Convert.ToInt32(dr["intAllotedExerciseMinutes"]);
        List<Day> lstHistory = DayDAL.GetDaysByUser(intUserID).ToList();

        User user = User.of(strUsername, intWeight, intHeightInInches, exerciseLevel, intAllotedCalories, intAllotedExerciseMinutes, lstHistory);

        return user;
    }

    public static bool InsertUser(User newUser)
    {
        string tmpExerciseLevel = "";
        switch (newUser.exerciseLevel)
        {
            case ExerciseLevel.LowIntensity:
                tmpExerciseLevel = "low";
                break;
            case ExerciseLevel.MediumIntensity:
                tmpExerciseLevel = "med";
                break;
            case ExerciseLevel.HighIntensity:
                tmpExerciseLevel = "high";
                break;
        }


        // create and open connection
        NpgsqlConnection conn = DatabaseConnection.GetConnection();
        conn.Open();

        // define a query
        string query = "INSERT INTO public.\"user\"(" +
            " \"strUsername\", \"intWeight\", \"intHeightInInches\", \"exerciseLevel\", \"intAllotedCalories\", \"intAllotedExerciseMinutes\")" +
            " VALUES( @strUsername," +
            " @intWeight," +
            " @intHeightInInches," +
            " '" + tmpExerciseLevel + "'," +
            " @intAllotedCalories," +
            " @intAllotedExerciseMinutes);";
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        cmd.Parameters.AddWithValue("strUsername", newUser.strUsername);
        cmd.Parameters.AddWithValue("intWeight", newUser.intWeight);
        cmd.Parameters.AddWithValue("intHeightInInches", newUser.intHeightInInches);
        //cmd.Parameters.AddWithValue("exerciseLevel", newUser.exerciseLevel);
        cmd.Parameters.AddWithValue("intAllotedCalories", newUser.intAllotedCalories);
        cmd.Parameters.AddWithValue("intAllotedExerciseMinutes", newUser.intAllotedExerciseMinutes);

        // execute query
        int result = cmd.ExecuteNonQuery();

        conn.Close();


        if (result == 1)
            return true;
        else
            return false;
    }

    public static User GetUser(int intUserID)
    {
        User retval = null;

        // create and open connection
        NpgsqlConnection conn = DatabaseConnection.GetConnection();
        conn.Open();

        // define a query
        string query = "SELECT * FROM \"user\" WHERE \"intUserID\" = " + intUserID;
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        // execute query
        NpgsqlDataReader dr = cmd.ExecuteReader();

        // read all rows and output the first column in each row
        while (dr.Read())
        {
            retval = GetUserFromDR(dr);
        }

        conn.Close();

        return retval;
    }

    public static User GetUserByUsername(string strUsername)
    {
        User retval = null;

        // create and open connection
        NpgsqlConnection conn = DatabaseConnection.GetConnection();
        conn.Open();

        // define a query
        string query = "SELECT * FROM \"user\" WHERE \"strUsername\" = '" + strUsername + "'";
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        // execute query
        NpgsqlDataReader dr = cmd.ExecuteReader();

        // read all rows and output the first column in each row
        while (dr.Read())
        {
            retval = GetUserFromDR(dr);
        }

        conn.Close();

        return retval;
    }

}