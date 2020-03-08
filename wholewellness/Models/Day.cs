using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.Models
{

    public class Day
    {
        [Key]

        [Display(Name = "Meals Added")]
        public List<Meal> mealsAdded { get; set; }

        [Display(Name = "Exercise Completed")]
        public List<WorkoutRoutine> exerciseCompleted { get; set; }

        [Display(Name = "Calories Remaining")]
        public int caloriesRemaining { get; set; }

        public Day(List<Meal> mealsAdded, List<WorkoutRoutine> exerciseCompleted, int caloriesRemaining)
        {
            this.mealsAdded = mealsAdded;
            this.exerciseCompleted = exerciseCompleted;
            this.caloriesRemaining = caloriesRemaining;
        }

        public Day of(List<Meal> mealsAdded, List<WorkoutRoutine> exerciseCompleted, int caloriesRemaining)
        {
            return new Day(Meal, exerciseCompleted, caloriesRemaining);
        }
    }
}
