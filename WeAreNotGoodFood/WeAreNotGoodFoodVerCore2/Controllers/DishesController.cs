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
using Microsoft.Extensions.Logging;
using WeAreNotGoodFoodVerCore2.Data;
using WeAreNotGoodFoodVerCore2.Models;
using WeAreNotGoodFoodVerCore2.Services;

namespace WeAreNotGoodFoodVerCore2.Controllers
{
    public class DishesController : Controller
    {
        #region Conect and Ctor

        public DishesController(
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

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dishes
                .Include(d => d.Restaurant)
                .OrderByDescending(r => r.Id);

            return View(await applicationDbContext.ToListAsync());
        }

        #endregion

        #region Details

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.Restaurant)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        #endregion

        #region Create

        // GET: Dishes/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id");
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameDish,ImagesDish,Price,Description,RestaurantId,Id")] Dish dish, DishVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var dishUp = Dish(dish, model);
                dishUp.UserId = user.Id;

                _context.Add(dishUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", dish.RestaurantId);
            return View(dish);
        }

        #endregion

        #region Edit

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.SingleOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", dish.RestaurantId);
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NameDish,ImagesDish,Price,Description,RestaurantId,Id")] Dish dish, DishVM model)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }
            var searching = await _context.Dishes.SingleOrDefaultAsync(s => s.Id == id);
            if (ModelState.IsValid)
            {
                try
                {

                    var path = Path.Combine(_environment.WebRootPath,
                        $"images\\{_userManager.GetUserName(User)}\\Publication");

                    _fileUploadService.Upload(path, model.ImagesDish.FileName, model.ImagesDish);
                    var imageUrlContent =
                        $"images/{_userManager.GetUserName(User)}/Publication/{model.ImagesDish.FileName}";

                    searching.Description = dish.Description;
                    searching.ImagesDish = imageUrlContent;

                    _context.Update(searching);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
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
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", dish.RestaurantId);
            return View(dish);
        }

        #endregion

        #region Delete

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.Restaurant)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Exsist

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }

        #endregion

        #region RestaurantUpload

        private Dish Dish(Dish dish, DishVM model)
        {
            var path = Path.Combine(_environment.WebRootPath, $"images\\{_userManager.GetUserName(User)}\\Publication");

            _fileUploadService.Upload(path, model.ImagesDish.FileName, model.ImagesDish);
            var imageUrlContent = $"images/{_userManager.GetUserName(User)}/Publication/{model.ImagesDish.FileName}";

            var dishNew = new Dish
            {
                NameDish = dish.NameDish,
                ImagesDish = imageUrlContent,
                Description = dish.Description,
                Price = dish.Price,
                RestaurantId = dish.RestaurantId
            };

            return dishNew;
        }

        #endregion
    }
}
