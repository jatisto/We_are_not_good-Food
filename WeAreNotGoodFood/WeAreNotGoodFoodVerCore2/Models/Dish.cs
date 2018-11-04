using System.ComponentModel.DataAnnotations;

namespace WeAreNotGoodFoodVerCore2.Models
{
    public class Dish : Entity
    {
        public string NameDish { get; set; }
        public string ImagesDish { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        [Display(Name = "Имя пользователя")] public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}