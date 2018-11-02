using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Laboratory56.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeAreNotGoodFood.Data;
using WeAreNotGoodFood.Models;

namespace WeAreNotGoodFood.Controllers
{
    public class RestaurantsController : Controller
    {
        #region Conection and ctor

        public RestaurantsController(ApplicationDbContext context, IHostingEnvironment environment,
            FileUploadService fileUploadService)
        {
            _context = context;
            _environment = environment;
            _fileUploadService = fileUploadService;
        }

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly FileUploadService _fileUploadService;

        #endregion

        #region Index

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurants.ToListAsync());
        }

        #endregion

        #region Details

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        #endregion

        #region Create

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ImagesRestaurant,Description,Id")] Restaurant restaurant, RestaurantVM model)
        {
            if (ModelState.IsValid)
            {
//                var user = await _userManager.GetUserAsync(User);
//                var restaurantUpload = Restaurant(restaurant, model);
//                restaurantUpload.Id = user.Id;
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        #endregion

        #region Edit

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,ImagesRestaurant,Description,Id")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        #endregion

        #region Delete

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Exists

        private bool RestaurantExists(string id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }

        #endregion

        #region PublicationUpload

        /*private Restaurant Restaurant(Restaurant restaurant, RestaurantVM model)
        {
            var path = Path.Combine(_environment.WebRootPath, $"images\\{_userManager.GetUserName(User)}\\Publication");

            _fileUploadService.Upload(path, model.ImagesRestaurant.FileName, model.ImagesRestaurant);
            var imageUrlRestaurant = $"images/{_userManager.GetUserName(User)}/Publication/{model.ImagesRestaurant.FileName}";

            var pub = new Restaurant
            {
                ImagesRestaurant = imageUrlRestaurant,
                Description = restaurant.Description
            };

            return pub;
        }*/

        #endregion	
    }
}
