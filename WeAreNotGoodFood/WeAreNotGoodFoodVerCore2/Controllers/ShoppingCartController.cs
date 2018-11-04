using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeAreNotGoodFoodVerCore2.Data;
using WeAreNotGoodFoodVerCore2.Interfaces;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDishRepository _dishRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(IDishRepository dishRepository, 
            ShoppingCart shoppingCart,
            ApplicationDbContext context)
        {
            _dishRepository = dishRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int dishId)
        {
            var selectedDish = _dishRepository.Dishes.FirstOrDefault(p => p.Id == dishId);
            if (selectedDish != null)
            {
                _shoppingCart.AddToCart(selectedDish, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int dishId)
        {
            var selectedDish = _dishRepository.Dishes.FirstOrDefault(p => p.Id == dishId);
            if (selectedDish != null)
            {
                _shoppingCart.RemoveFromCart(selectedDish);
            }
            return RedirectToAction("Index");
        }
    }
}