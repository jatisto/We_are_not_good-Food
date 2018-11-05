namespace WeAreNotGoodFoodVerCore2.Models
{
    public class ShoppingCartItem : Entity
    {
        public string ShoppingCartItemId { get; set; }
        public Dish Dish { get; set; }

        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}