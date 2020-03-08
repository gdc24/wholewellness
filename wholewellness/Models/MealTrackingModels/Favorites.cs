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

        [Display(Name = "Favorites")]
        public List<FoodItem> favorites { get; set; }


        public Favorites(List<FoodItem> favorites)
        {
            this.favorites = favorites;
        }

        public Favorites of(List<FoodItem> favorities)
        {
            return new Favorites(favorites);
        }
    }
}
