using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeAreNotGoodFood.Models
{
    public class RestaurantVM
    {
        public string Name { get; set; }
        public IFormFile ImagesRestaurant { get; set; }
        public string Description { get; set; }
        public List<Dish> DishList { get; set; }
    }
}
