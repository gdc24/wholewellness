using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models.ExerciseTrackingModels
{
    public class WorkoutRoutine
    {

        [Key]
        [Display(Name = "Workout Routine ID")]
        public int intWorkoutRoutineID { get; set; }

        [Display(Name = "Total Workout Routine Minutes")]
        public int intTotalMinutes { get; set; }

        [Display(Name = "Routine")]
        public List<ExerciseType> lstRoutine { get; set; }

        [Display(Name = "Total Calories Burned")]
        public int intTotalCalsBurned { get; set; }

        public WorkoutRoutine(int intTotalMinutes, List<ExerciseType> lstRoutine, int intTotalCalsBurned)
        {
            this.intTotalMinutes = intTotalMinutes;
            this.lstRoutine = lstRoutine;
            this.intTotalCalsBurned = intTotalCalsBurned;
        }

        public static WorkoutRoutine of(int intTotalMinutes, List<ExerciseType> lstRoutine, int intTotalCalsBurned)
        {
            return new WorkoutRoutine(intTotalMinutes, lstRoutine, intTotalCalsBurned);
        }
    }
}
