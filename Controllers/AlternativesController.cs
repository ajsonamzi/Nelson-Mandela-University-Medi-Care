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
    public class AlternativesController : Controller
    {
        private readonly MediCare2_0Context _context;

        public AlternativesController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: Alternatives
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

            var alt = from a in _context.Alternative
                      select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                alt = alt.Where(d => d.alternativeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    alt = alt.OrderByDescending(d => d.alternativeName);
                    break;
                default:
                    alt = alt.OrderBy(d => d.alternativeName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Alternative>.CreateAsync(alt.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: Alternatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alternative == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative
                .FirstOrDefaultAsync(m => m.alternativeID == id);
            if (alternative == null)
            {
                return NotFound();
            }

            return View(alternative);
        }

        // GET: Alternatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alternatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alternativeID,alternativeName")] Alternative alternative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alternative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alternative);
        }

        // GET: Alternatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alternative == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative.FindAsync(id);
            if (alternative == null)
            {
                return NotFound();
            }
            return View(alternative);
        }

        // POST: Alternatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alternativeID,alternativeName")] Alternative alternative)
        {
            if (id != alternative.alternativeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alternative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlternativeExists(alternative.alternativeID))
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
            return View(alternative);
        }

        // GET: Alternatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alternative == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative
                .FirstOrDefaultAsync(m => m.alternativeID == id);
            if (alternative == null)
            {
                return NotFound();
            }

            return View(alternative);
        }

        // POST: Alternatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alternative == null)
            {
                return Problem("Entity set 'MediCare2_0Context.Alternative'  is null.");
            }
            var alternative = await _context.Alternative.FindAsync(id);
            if (alternative != null)
            {
                _context.Alternative.Remove(alternative);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlternativeExists(int id)
        {
          return _context.Alternative.Any(e => e.alternativeID == id);
        }
    }
}
