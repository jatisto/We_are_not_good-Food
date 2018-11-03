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
using WeAreNotGoodFoodVerCore2.Data;
using WeAreNotGoodFoodVerCore2.Models;

namespace WeAreNotGoodFoodVerCore2.Controllers
{
    public class RestaurantsController : Controller
    {
        #region Conect and Ctor

        public RestaurantsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment environment,
            FileUploadService fileUploadService,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            _fileUploadService = fileUploadService;
            _context = context;
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _environment;
        private readonly FileUploadService _fileUploadService;

        #endregion

        #region Index

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Restaurants
                .Include(r => r.User)
                .OrderByDescending(r => r.Id);

            return View(await applicationDbContext.ToListAsync());
        }

        #endregion

        #region Details

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ImagesRestaurant,Description,UserId,Id")]
            Restaurant restaurant, RestaurantVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var restaurantUp = Restaurant(restaurant, model);
                restaurantUp.UserId = user.Id;

                _context.Add(restaurantUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", restaurant.UserId);
            return View(restaurant);
        }

        #endregion

        #region Edit

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", restaurant.UserId);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Name,ImagesRestaurant,Description,UserId,Id")]
            Restaurant restaurant,
            RestaurantVM model)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            var searching = await _context.Restaurants.SingleOrDefaultAsync(s => s.Id == id);
            if (ModelState.IsValid)
            {
                try
                {
                    var path = Path.Combine(_environment.WebRootPath,
                        $"images\\{_userManager.GetUserName(User)}\\Publication");

                    _fileUploadService.Upload(path, model.ImagesRestaurant.FileName, model.ImagesRestaurant);
                    var imageUrlContent =
                        $"images/{_userManager.GetUserName(User)}/Publication/{model.ImagesRestaurant.FileName}";

                    searching.Description = restaurant.Description;
                    searching.ImagesRestaurant = imageUrlContent;

                    _context.Update(searching);
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

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", restaurant.UserId);
            return View(restaurant);
        }

        #endregion

        #region Delete

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Exists

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }

        #endregion

        #region RestaurantUpload

        private Restaurant Restaurant(Restaurant restaurant, RestaurantVM model)
        {
            var path = Path.Combine(_environment.WebRootPath, $"images\\{_userManager.GetUserName(User)}\\Publication");

            _fileUploadService.Upload(path, model.ImagesRestaurant.FileName, model.ImagesRestaurant);
            var imageUrlContent =
                $"images/{_userManager.GetUserName(User)}/Publication/{model.ImagesRestaurant.FileName}";

            var resistor = new Restaurant
            {
                Name = restaurant.Name,
                ImagesRestaurant = imageUrlContent,
                Description = restaurant.Description
            };

            return resistor;
        }

        #endregion
    }
}