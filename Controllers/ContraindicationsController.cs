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
    public class ContraindicationsController : Controller
    {
        private readonly MediCare2_0Context _context;

        public ContraindicationsController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: Contraindications
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

            var contra = from d in _context.Contraindiction
                         select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                contra = contra.Where(d => d.contraindicationName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    contra = contra.OrderByDescending(d => d.contraindicationName);
                    break;
                default:
                    contra = contra.OrderBy(d => d.contraindicationName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Contraindication>.CreateAsync(contra.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: Contraindications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contraindiction == null)
            {
                return NotFound();
            }

            var contraindication = await _context.Contraindiction
                .FirstOrDefaultAsync(m => m.contraindicationID == id);
            if (contraindication == null)
            {
                return NotFound();
            }

            return View(contraindication);
        }

        // GET: Contraindications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contraindications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("contraindicationID,contraindicationName")] Contraindication contraindication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contraindication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contraindication);
        }

        // GET: Contraindications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contraindiction == null)
            {
                return NotFound();
            }

            var contraindication = await _context.Contraindiction.FindAsync(id);
            if (contraindication == null)
            {
                return NotFound();
            }
            return View(contraindication);
        }

        // POST: Contraindications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("contraindicationID,contraindicationName")] Contraindication contraindication)
        {
            if (id != contraindication.contraindicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contraindication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContraindicationExists(contraindication.contraindicationID))
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
            return View(contraindication);
        }

        // GET: Contraindications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contraindiction == null)
            {
                return NotFound();
            }

            var contraindication = await _context.Contraindiction
                .FirstOrDefaultAsync(m => m.contraindicationID == id);
            if (contraindication == null)
            {
                return NotFound();
            }

            return View(contraindication);
        }

        // POST: Contraindications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contraindiction == null)
            {
                return Problem("Entity set 'MediCare2_0Context.Contraindiction'  is null.");
            }
            var contraindication = await _context.Contraindiction.FindAsync(id);
            if (contraindication != null)
            {
                _context.Contraindiction.Remove(contraindication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContraindicationExists(int id)
        {
          return _context.Contraindiction.Any(e => e.contraindicationID == id);
        }
    }
}
