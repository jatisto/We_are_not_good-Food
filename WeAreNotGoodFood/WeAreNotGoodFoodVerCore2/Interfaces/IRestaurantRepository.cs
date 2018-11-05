using System.Collections.Generic;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> Restaurants { get; }
    }
}