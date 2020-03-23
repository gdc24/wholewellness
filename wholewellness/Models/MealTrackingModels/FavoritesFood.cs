using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models
{
    public class Favorites
    {

        [Key]
        [Display(Name = "Food Favorites ID")]
        public int intFavoritesFoodID { get; set; }

        [Display(Name = "Favorites")]
        public List<FoodItem> lstFavoritesFood { get; set; }


        public Favorites(List<FoodItem> lstFavoritesFood)
        {
            this.lstFavoritesFood = lstFavoritesFood;
        }

        public Favorites of(List<FoodItem> lstFavoritesFood)
        {
            return new Favorites(lstFavoritesFood);
        }
    }
}
