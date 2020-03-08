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

        [Display(Name = "Username")]
        public String username { get; set; }

        [Display(Name = "Weight")]
        public double weight { get; set; }

        [Display(Name = "Height (In Inches)")]
        public double heightInInches { get; set; }

        [Display(Name = "Exercise Level")]
        public ExerciseLevel exerciseLevel { get; set; }

        [Display(Name = "Alloted Calories")]
        public int allotedCalories { get; set; }

        [Display(Name = "Alloted Exercise Minutes")]
        public int allotedExerciseMinutes { get; set; }

        [Display(Name = "History")]
        public List<Day> history { get; set; }


        public User(String username, double weight, double heightInInches, ExerciseLevel exerciseLevel, int allotedCalories,
            int allotedExerciseMinutes, List<Day> history)
        {
            this.username = username;
            this.weight = weight;
            this.heightInInches = heightInInches;
            this.exerciseLevel = exerciseLevel;
            this.allotedCalories = allotedCalories;
            this.allotedExerciseMinutes = allotedExerciseMinutes;
            this.history = history;
        }

        public User of(String username, double weight, double heightInInches, ExerciseLevel exerciseLevel, int allotedCalories,
            int allotedExerciseMinutes, List<Day> history)
        {
            return new User(username, weight, heightInInches, exerciseLevel, allotedCalories, allotedExerciseMinutes, history);
        }
    }
}
