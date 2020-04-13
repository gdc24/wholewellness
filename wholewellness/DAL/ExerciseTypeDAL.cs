﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.DAL
{
    public class ExerciseTypeDAL
    {
        private static ExerciseType GetExerciseFromDR(NpgsqlDataReader dr)
        {
            int intExerciseTypeID = Convert.ToInt32(dr["intExerciseTypeID"]);
            string strName = dr["strName"].ToString();
            int intCaloriesBurned = Convert.ToInt32(dr["intCaloriesBurned"]);
            bool ysnAccessibility = Convert.ToBoolean(dr["ysnAccessibility"]);
            MuscleGroup muscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), dr["muscleGroup"].ToString());
            Equipment equipment = (Equipment)Enum.Parse(typeof(Equipment), dr["equipment"].ToString());
            Intensity intensity = GetIntensityFromDB(dr["intensity"]);
            int intTime = Convert.ToInt32(dr["intTime"]);

            ExerciseType foodItem = ExerciseType.of(muscleGroup, strName, intCaloriesBurned, ysnAccessibility, intensity, equipment, intTime);

            return foodItem;
        }

        private static List<Equipment> GetEquipmentList(int intExerciseTypeID)
        {
            //TODO
            throw new NotImplementedException();
        }

        internal static bool AddExerciseType(ExerciseType newExercise)
        {
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "INSERT INTO public.\"exerciseType\"(" +
                " \"muscleGroup\", equipment, \"intCaloriesBurned\", \"ysnAccessibility\", \"intTime\", intensity, \"strName\")" +
                " VALUES('" + newExercise.muscleGroup.ToString() + "'," +
                " '" + newExercise.equipment.ToString() + "'," +
                " @intCaloriesBurned, @ysnAccessibility, @intTime," +
                " '" + GetDBIntensityFromEnum(newExercise.intensity) + "'," +
                " @strName); ";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("muscleGroup", );
            //cmd.Parameters.AddWithValue("equipment", newFoodItem.intCalories);
            cmd.Parameters.AddWithValue("intCaloriesBurned", newExercise.intCaloriesBurned);
            cmd.Parameters.AddWithValue("ysnAccessibility", newExercise.ysnAccessibility);
            cmd.Parameters.AddWithValue("intTime", newExercise.intTime);
            //cmd.Parameters.AddWithValue("intensity", newFoodItem.intCalories);
            cmd.Parameters.AddWithValue("strName", newExercise.strName.ToLower());

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            if (result == 1)
                return true;
            else
                return false;
        }

        internal static List<ExerciseType> GetExercisesByWorkout(int intWorkoutRoutineID)
        {
            //TODO
            throw new NotImplementedException();
        }

        //TODO search methods

        private static Intensity GetIntensityFromDB(object fromDB)
        {
            string strIntensity = fromDB.ToString();
            Intensity retval = 0;
            switch (strIntensity)
            {
                case "low":
                    retval = Intensity.Low;
                    break;
                case "med":
                    retval = Intensity.Medium;
                    break;
                case "high":
                    retval = Intensity.High;
                    break;
            }

            return retval;
        }
        
        private static string GetDBIntensityFromEnum(Intensity intensity)
        {
            string retval = "";
            switch (intensity)
            {
                case Intensity.Low:
                    retval = "low";
                    break;
                case Intensity.Medium:
                    retval = "med";
                    break;
                case Intensity.High:
                    retval = "high";
                    break;
            }

            return retval;
        }



        private static List<MuscleGroup> GetMuscleGroupList(int intExerciseTypeID)
        {
            List<MuscleGroup> retval = new List<MuscleGroup>();

            // create and open connection
            NpgsqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            // define a query
            string query = "SELECT \"muscleGroup\" FROM \"muscleExercise\" WHERE intExerciseTypeID = " + intExerciseTypeID;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

            // execute query
            NpgsqlDataReader dr = cmd.ExecuteReader();

            // read all rows and output the first column in each row
            while (dr.Read())
            {
                MuscleGroup muscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), dr["muscleGroup"].ToString());
                retval.Add(muscleGroup);
            }

            conn.Close();

            return retval;
        }
    }
}