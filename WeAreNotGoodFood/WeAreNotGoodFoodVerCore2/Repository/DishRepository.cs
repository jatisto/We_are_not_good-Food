using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WeAreNotGoodFoodVerCore2.Data;
using WeAreNotGoodFoodVerCore2.Interfaces;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;

        public DishRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Dish> Dishes => _context.Dishes.Include(c => c.Restaurant);

        public IEnumerable<Dish> PreferredDishes =>
            _context.Dishes.Where(p => p.IsPreferredDish).Include(c => c.Restaurant);


        public Dish GetDisheById(int dishId) => _context.Dishes.FirstOrDefault(p => p.Id == dishId);
    }
}