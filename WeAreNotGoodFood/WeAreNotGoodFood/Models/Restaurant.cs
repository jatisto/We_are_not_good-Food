using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAreNotGoodFood.Models
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public string ImagesRestaurant { get; set; }
        public string Description { get; set; }

        public List<Dish> DishList { get; set; }
    }
}
