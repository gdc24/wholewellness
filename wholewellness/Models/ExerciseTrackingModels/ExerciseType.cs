using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models.ExerciseTrackingModels
{
    public class ExerciseType
    {
        [Key]

        [Display(Name = "Muscle Groups")]
        public List<MuscleGroup> muscleGroups { get; set; }

        [Display(Name = "Name")]
        public String name { get; set; }

        [Display(Name = "Calories Burned")]
        public int caloriesBurned { get; set; }

        [Display(Name = "Accessibility")]
        public Boolean accessibility { get; set; }

        [Display(Name = "Intensity")]
        public Intensity intensity { get; set; }


        [Display(Name = "Time")]
        public int time { get; set; }

        public ExerciseType(List<MuscleGroup> muscleGroups, String name, int caloriesBurned, Boolean accessibility,
            Intensity intensity, int time)
        {
            this.muscleGroups = muscleGroups;
            this.name = name;
            this.caloriesBurned = caloriesBurned;
            this.accessibility = accessibility;
            this.intensity = intensity;
            this.time = time;
        }

        public ExerciseType of(List<MuscleGroup> muscleGroups, String name, int caloriesBurned, Boolean accessibility,
            Intensity intensity, int time)
        {
            return new ExerciseType(muscleGroups, name, caloriesBurned, accessibility, intensity, time);
        }
    }
}
