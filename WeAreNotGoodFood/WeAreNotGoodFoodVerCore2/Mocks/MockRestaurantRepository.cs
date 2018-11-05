using System.Collections.Generic;
using WeAreNotGoodFoodVerCore2.Interfaces;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Mocks
{
    public class MockRestaurantRepository : IRestaurantRepository
    {
        public IEnumerable<Restaurant> Restaurants
        {
            get
            {
                return new List<Restaurant>
                {
                    new Restaurant
                    {
                        ImagesRestaurant =
                            @"C:\home\Git_work\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Resraurant\images (8).jpg",
                        Name = "Alcoholic",
                        Description = "Уютно и приятно"
                    },
                    new Restaurant
                    {
                        ImagesRestaurant =
                            @"C:\home\Git_work\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Resraurant\загруже13но.jpg",
                        Name = "Не пьющий саловей",
                        Description = "Если ты к нам пришёл то уже не забудеш"
                    },
                    new Restaurant
                    {
                        ImagesRestaurant =
                            @"C:\home\Git_work\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Resraurant\загружено (2).jpg",
                        Name = "Красивая жизнь",
                        Description = "Ну это про нас!"
                    },

                };
            }
        }
    }
}