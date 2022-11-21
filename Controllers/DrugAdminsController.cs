using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediCare2._0.Data;
using MediCare2._0.Models;

namespace MediCare2._0.Controllers
{
    public class DrugAdminsController : Controller
    {
        private readonly MediCare2_0Context _context;

        public DrugAdminsController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: DrugAdmins
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var admin = from d in _context.DrugAdmin
                        select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                admin = admin.Where(d => d.adminType.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    admin = admin.OrderByDescending(d => d.adminType);
                    break;
                default:
                    admin = admin.OrderBy(d => d.adminType);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<DrugAdmin>.CreateAsync(admin.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: DrugAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DrugAdmin == null)
            {
                return NotFound();
            }

            var drugAdmin = await _context.DrugAdmin
                .FirstOrDefaultAsync(m => m.drugAdminID == id);
            if (drugAdmin == null)
            {
                return NotFound();
            }

            return View(drugAdmin);
        }

        // GET: DrugAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrugAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drugAdminID,adminType")] DrugAdmin drugAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drugAdmin);
        }

        // GET: DrugAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DrugAdmin == null)
            {
                return NotFound();
            }

            var drugAdmin = await _context.DrugAdmin.FindAsync(id);
            if (drugAdmin == null)
            {
                return NotFound();
            }
            return View(drugAdmin);
        }

        // POST: DrugAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drugAdminID,adminType")] DrugAdmin drugAdmin)
        {
            if (id != drugAdmin.drugAdminID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugAdminExists(drugAdmin.drugAdminID))
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
            return View(drugAdmin);
        }

        // GET: DrugAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DrugAdmin == null)
            {
                return NotFound();
            }

            var drugAdmin = await _context.DrugAdmin
                .FirstOrDefaultAsync(m => m.drugAdminID == id);
            if (drugAdmin == null)
            {
                return NotFound();
            }

            return View(drugAdmin);
        }

        // POST: DrugAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DrugAdmin == null)
            {
                return Problem("Entity set 'MediCare2_0Context.DrugAdmin'  is null.");
            }
            var drugAdmin = await _context.DrugAdmin.FindAsync(id);
            if (drugAdmin != null)
            {
                _context.DrugAdmin.Remove(drugAdmin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugAdminExists(int id)
        {
          return _context.DrugAdmin.Any(e => e.drugAdminID == id);
        }
    }
}
