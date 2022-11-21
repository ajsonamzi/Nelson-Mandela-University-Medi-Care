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
    public class PhasesController : Controller
    {
        private readonly MediCare2_0Context _context;

        public PhasesController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: Phases
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

            var phase = from p in _context.Phase
                        select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                phase = phase.Where(d => d.phaseStage.Contains(searchString)
                || d.phaseDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    phase = phase.OrderByDescending(d => d.phaseStage);
                    break;
                default:
                    phase = phase.OrderBy(d => d.phaseStage);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Phase>.CreateAsync(phase.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: Phases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phase == null)
            {
                return NotFound();
            }

            var phase = await _context.Phase
                .FirstOrDefaultAsync(m => m.phaseID == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // GET: Phases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("phaseID,phaseStage,phaseDescription")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phase);
        }

        // GET: Phases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phase == null)
            {
                return NotFound();
            }

            var phase = await _context.Phase.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("phaseID,phaseStage,phaseDescription")] Phase phase)
        {
            if (id != phase.phaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.phaseID))
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
            return View(phase);
        }

        // GET: Phases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phase == null)
            {
                return NotFound();
            }

            var phase = await _context.Phase
                .FirstOrDefaultAsync(m => m.phaseID == id);
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phase == null)
            {
                return Problem("Entity set 'MediCare2_0Context.Phase'  is null.");
            }
            var phase = await _context.Phase.FindAsync(id);
            if (phase != null)
            {
                _context.Phase.Remove(phase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhaseExists(int id)
        {
          return _context.Phase.Any(e => e.phaseID == id);
        }
    }
}
