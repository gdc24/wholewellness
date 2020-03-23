using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models.ExerciseTrackingModels
{
    public class FavoritesExercise
    {
        [Key]
        [Display(Name = "Exercise Favorites ID")]
        public int intFavoritesExerciseID { get; set; }

        [Display(Name = "Exercise Favorites")]
        public List<ExerciseType> lstFavoritesExercise { get; set; }


        private FavoritesExercise(List<ExerciseType> lstFavoritesExercise)
        {
            this.lstFavoritesExercise = lstFavoritesExercise;
        }

        public FavoritesExercise of(List<ExerciseType> lstFavoritesExercise)
        {
            return new FavoritesExercise(lstFavoritesExercise);
        }
    }
}
