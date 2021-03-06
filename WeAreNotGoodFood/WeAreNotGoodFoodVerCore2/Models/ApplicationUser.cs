﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WeAreNotGoodFoodVerCore2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Путь")]
        public string AvatarImage { get; set; }

        /*
        public List<Restaurant> RestaurantsList { get; set; }
        public List<Dish> DishList { get; set; }
        */
    }
}
