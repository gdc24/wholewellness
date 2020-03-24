using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models
{
    public class User
    {

        [Key]
        [Display(Name = "User ID")]
        public int intUserID { get; set; }

        [Display(Name = "Username")]
        public string strUsername { get; set; }

        [Display(Name = "Weight")]
        public int intWeight { get; set; }

        [Display(Name = "Height (In Inches)")]
        public int intHeightInInches { get; set; }

        [Display(Name = "Exercise Level")]
        public ExerciseLevel exerciseLevel { get; set; }

        [Display(Name = "Alloted Calories")]
        public int intAllotedCalories { get; set; }

        [Display(Name = "Alloted Exercise Minutes")]
        public int intAllotedExerciseMinutes { get; set; }

        [Display(Name = "History")]
        public List<Day> lstHistory { get; set; }


        public User(string strUsername, int intWeight, int intHeightInInches, ExerciseLevel exerciseLevel, int intAllotedCalories,
            int intAllotedExerciseMinutes, List<Day> lstHistory)
        {
            this.strUsername = strUsername;
            this.intWeight = intWeight;
            this.intHeightInInches = intHeightInInches;
            this.exerciseLevel = exerciseLevel;
            this.intAllotedCalories = intAllotedCalories;
            this.intAllotedExerciseMinutes = intAllotedExerciseMinutes;
            this.lstHistory = lstHistory;
        }

        public static User of(string strUsername, int intWeight, int intHeightInInches, ExerciseLevel exerciseLevel, int intAllotedCalories,
            int intAllotedExerciseMinutes, List<Day> lstHistory)
        {
            return new User(strUsername, intWeight, intHeightInInches, exerciseLevel, intAllotedCalories, intAllotedExerciseMinutes, lstHistory);
        }
    }
}
