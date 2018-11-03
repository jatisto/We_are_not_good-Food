using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAreNotGoodFoodVerCore2.Models
{
    public class ShoppingCart : Entity
    {
        public string DishId { get; set; }
        public Dish Dish { get; set; }

        public int Quantity { get; set; }
    }
}