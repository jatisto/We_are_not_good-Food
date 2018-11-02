namespace WeAreNotGoodFoodVerCore2.Models
{
    public class Dish : Entity
    {
        public string NameDish { get; set; }
        public string ImagesDish { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}