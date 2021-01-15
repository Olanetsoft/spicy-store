using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spicy.Data;
using Spicy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get Action methood that retreive everything in the Category and pass it to the view
        public async Task<IActionResult> Index()
        {
            return View(await _db.Category.ToListAsync());
        }


        // GET page for Create Category
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // If Valid
                _db.Category.Add(category);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

    }
}
