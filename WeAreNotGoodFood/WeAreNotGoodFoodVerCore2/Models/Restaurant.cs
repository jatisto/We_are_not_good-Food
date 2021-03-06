﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WeAreNotGoodFoodVerCore2.Models
{
    public class Restaurant : Entity
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Изображение")]
        public string ImagesRestaurant { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Имя пользователя")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<Dish> DishList { get; set; }
        public List<ShoppingCartItem> ShoppingCartItemsList { get; set; }


        /*public IEnumerator GetEnumerator()
        {
            return DishList.GetEnumerator();
        }*/
    }
}
