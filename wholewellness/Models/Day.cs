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
        [Display(Name = "Day ID")]
        public int intDayID { get; set; }

        [Display(Name = "Date")]
        public DateTime dtmDate { get; set; }

        [Display(Name = "Meals Added")]
        public List<Meal> lstMealsAdded { get; set; }

        [Display(Name = "Exercise Completed")]
        public List<WorkoutRoutine> lstExerciseCompleted { get; set; }

        [Display(Name = "Calories Remaining")]
        public int intCalsLeft { get; set; }

        public Day(int intDayID, List<Meal> lstMealsAdded, DateTime dtmDate, List<WorkoutRoutine> lstExerciseCompleted, int intCalsLeft)
        {
            this.intDayID = intDayID;
            this.lstMealsAdded = lstMealsAdded;
            this.dtmDate = dtmDate;
            this.lstExerciseCompleted = lstExerciseCompleted;
            this.intCalsLeft = intCalsLeft;
        }

        public static Day of(int intDayID, List<Meal> lstMealsAdded, DateTime dtmDate, List<WorkoutRoutine> lstExerciseCompleted, int intCalsLeft)
        {
            return new Day(intDayID, lstMealsAdded, dtmDate, lstExerciseCompleted, intCalsLeft);
        }
    }
}
