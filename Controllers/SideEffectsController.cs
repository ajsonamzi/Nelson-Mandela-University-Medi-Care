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
    public class SideEffectsController : Controller
    {
        private readonly MediCare2_0Context _context;

        public SideEffectsController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: SideEffects
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

            var side = from s in _context.SideEffect
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                side = side.Where(d => d.sideEffectName.Contains(searchString)
                || d.sideEffectDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    side = side.OrderByDescending(d => d.sideEffectName);
                    break;
                case "Date":
                    side = side.OrderBy(d => d.sideEffectDate);
                    break;
                case "date_desc":
                    side = side.OrderByDescending(d => d.sideEffectDate);
                    break;
                default:
                    side = side.OrderBy(d => d.sideEffectName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<SideEffect>.CreateAsync(side.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: SideEffects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SideEffect == null)
            {
                return NotFound();
            }

            var sideEffect = await _context.SideEffect
                .FirstOrDefaultAsync(m => m.sideEffectID == id);
            if (sideEffect == null)
            {
                return NotFound();
            }

            return View(sideEffect);
        }

        // GET: SideEffects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SideEffects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sideEffectID,sideEffectName,sideEffectDescription,sideEffectDate")] SideEffect sideEffect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sideEffect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sideEffect);
        }

        // GET: SideEffects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SideEffect == null)
            {
                return NotFound();
            }

            var sideEffect = await _context.SideEffect.FindAsync(id);
            if (sideEffect == null)
            {
                return NotFound();
            }
            return View(sideEffect);
        }

        // POST: SideEffects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sideEffectID,sideEffectName,sideEffectDescription,sideEffectDate")] SideEffect sideEffect)
        {
            if (id != sideEffect.sideEffectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sideEffect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SideEffectExists(sideEffect.sideEffectID))
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
            return View(sideEffect);
        }

        // GET: SideEffects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SideEffect == null)
            {
                return NotFound();
            }

            var sideEffect = await _context.SideEffect
                .FirstOrDefaultAsync(m => m.sideEffectID == id);
            if (sideEffect == null)
            {
                return NotFound();
            }

            return View(sideEffect);
        }

        // POST: SideEffects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SideEffect == null)
            {
                return Problem("Entity set 'MediCare2_0Context.SideEffect'  is null.");
            }
            var sideEffect = await _context.SideEffect.FindAsync(id);
            if (sideEffect != null)
            {
                _context.SideEffect.Remove(sideEffect);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SideEffectExists(int id)
        {
          return _context.SideEffect.Any(e => e.sideEffectID == id);
        }
    }
}
