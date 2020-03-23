using System;
using Npgsql;
using wholewellness.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserDAL
{
	public UserDAL()
	{
		private static User GetUserFromDR(NpgsqlDataReader dr)
        {
            int intUserID = Convert.ToInt32(dr["intUserID"]);
            string strUsername = dr["strUsername"].ToString();
            int intWeight = Convert.ToInt32(dr["intWeight"]);
            int intHeightInInches = Convert.ToInt32(dr["intHeightInInches"]);
            ExerciseLevel exerciseLevel = Enum.Parse(wholewellness.Models.ExerciseLevel, dr["exerciseLevel"].ToString());
            int intAllotedCalories = Convert.ToInt32(dr["intAllotedCalories"]);
            int intAllotedExerciseMinutes = Convert.ToInt32(dr["intAllotedExerciseMinutes"]);

            User user = User.of(strUsername, intWeight, intHeightInInches, exerciseLevel, intAllotedCalories, intAllotedExerciseMinutes);

            return user;
        }
	}
}
