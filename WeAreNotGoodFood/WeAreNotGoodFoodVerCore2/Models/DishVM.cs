using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeAreNotGoodFoodVerCore2.Models
{
    public class DishVM
    {
        public string NameDish { get; set; }
        public IFormFile ImagesDish { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
