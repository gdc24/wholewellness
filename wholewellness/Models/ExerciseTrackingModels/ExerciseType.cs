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
        [Display(Name = "Exercise Type ID")]
        public int intExerciseTypeID { get; set; }

        [Display(Name = "Muscle Groups")]
        public List<MuscleGroup> lstMuscleGroups { get; set; }

        [Display(Name = "Name")]
        public String strName { get; set; }

        [Display(Name = "Calories Burned")]
        public int intCaloriesBurned { get; set; }

        [Display(Name = "Accessibility")]
        public Boolean ysnAccessibility { get; set; }

        [Display(Name = "Intensity")]
        public Intensity intensity { get; set; }


        [Display(Name = "Time")]
        public int intTime { get; set; }

        private ExerciseType(List<MuscleGroup> lstMuscleGroups, String strName, int intCaloriesBurned, Boolean ysnAccessibility,
            Intensity intensity, int intTime)
        {
            this.lstMuscleGroups = lstMuscleGroups;
            this.strName = strName;
            this.intCaloriesBurned = intCaloriesBurned;
            this.ysnAccessibility = ysnAccessibility;
            this.intensity = intensity;
            this.intTime = intTime;
        }

        public ExerciseType of(List<MuscleGroup> lstMuscleGroups, String strName, int intCaloriesBurned, Boolean ysnAccessibility,
            Intensity intensity, int intTime)
        {
            return new ExerciseType(lstMuscleGroups, strName, intCaloriesBurned, ysnAccessibility, intensity, intTime);
        }
    }
}
