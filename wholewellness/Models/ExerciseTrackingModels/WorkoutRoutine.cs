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

        [Display(Name = "Time")]
        public int time { get; set; }

        [Display(Name = "Routine")]
        public List<ExerciseType> routine { get; set; }

        [Display(Name = "Total Calories Burned")]
        public int totalCaloriesBurned { get; set; }

        public WorkoutRoutine(int time, List<ExerciseType> routine, int totalCaloriesBurned)
        {
            this.time = time;
            this.routine = routine;
            this.totalCaloriesBurned = totalCaloriesBurned;
        }

        public WorkoutRoutine of(int time, List<ExerciseType> routine, int totalCaloriesBurned)
        {
            return new WorkoutRoutine(time, routine, totalCaloriesBurned);
        }
    }
}
