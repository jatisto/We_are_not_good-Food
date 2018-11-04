using System.Collections.Generic;
using WeAreNotGoodFoodVerCore2.Interfaces;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Mocks
{
    public class MockDishRepository : IDishRepository
    {
        public IEnumerable<Dish> Dishes
        {
            get
            {
                return new List<Dish>
                {
                    new Dish
                    {
                        NameDish = "Пельмень жареный",
                        ImagesDish = @"C:\Users\evgen\GitFolderHome\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Dish\загружено (3).jpg",
                        Description = "Пельмень жареный с соусом morinaro",
                        Price = 250,
                        RestaurantId = 1
                    },
                    new Dish
                    {
                        NameDish = "Мясо по кавказски",
                        ImagesDish = @"C:\Users\evgen\GitFolderHome\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Dish\00080202.jpg",
                        Description = "С тушеными овощами отлично сочетается наше мясо гриль по-кавказски, которое представляет собой кусочки нежирного свиного",
                        Price = 750,
                        RestaurantId = 2
                    },
                    new Dish
                    {
                        NameDish = "Лапша китайская обыкновенная",
                        ImagesDish = @"C:\Users\evgen\GitFolderHome\We_are_not_good-Food\WeAreNotGoodFood\WeAreNotGoodFoodVerCore2\wwwroot\images\Dish\images (7).jpg",
                        Description = "лапша, лук, перец и т.д.",
                        Price = 200,
                        RestaurantId = 3
                    }
                };
            }   
    }

    public IEnumerable<Dish> PreferredDishes {
    get;
    }
    public Dish GetDisheById(int dishId)
    {
    throw new System.NotImplementedException();
}

}
}