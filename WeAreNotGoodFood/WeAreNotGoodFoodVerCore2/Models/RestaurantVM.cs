using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WeAreNotGoodFoodVerCore2.Models
{
    public class RestaurantVM
    {
        public string Name { get; set; }
        public IFormFile ImagesRestaurant { get; set; }
        public string Description { get; set; }
        public List<Dish> DishList { get; set; }
    }
}