using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spicy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicy.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubCategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get INDEX
        public async Task<IActionResult> Index()
        {
            var subCategory = await _db.SubCategory.Include(s=>s.Category).ToListAsync();

            return View(subCategory);
        }
    }
}
