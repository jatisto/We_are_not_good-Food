using System.Collections.Generic;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Interfaces
{
    public interface IDishRepository
    {
        IEnumerable<Dish> Dishes { get; }
        IEnumerable<Dish> PreferredDishes { get; }
        Dish GetDisheById(int dishId);
    }
}