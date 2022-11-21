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
    public class SymptomsController : Controller
    {
        private readonly MediCare2_0Context _context;

        public SymptomsController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: Symptoms
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

            var symptoms = from c in _context.Symptom
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                symptoms = symptoms.Where(d => d.symptomName.Contains(searchString)
                || d.symptomDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    symptoms = symptoms.OrderByDescending(d => d.symptomName);
                    break;
                case "Date":
                    symptoms = symptoms.OrderBy(d => d.symptomDate);
                    break;
                case "date_desc":
                    symptoms = symptoms.OrderByDescending(d => d.symptomDate);
                    break;
                default:
                    symptoms = symptoms.OrderBy(d => d.symptomName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Symptom>.CreateAsync(symptoms.AsNoTracking(), pageNumber ?? 1, pageSize));
            // return View(await _context.Drugs.ToListAsync()); 
        }

        // GET: Symptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Symptom == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptom
                .FirstOrDefaultAsync(m => m.symptomID == id);
            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

        // GET: Symptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Symptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("symptomID,symptomName,symptomDescription,symptomDate")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(symptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Symptom == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptom.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("symptomID,symptomName,symptomDescription,symptomDate")] Symptom symptom)
        {
            if (id != symptom.symptomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(symptom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SymptomExists(symptom.symptomID))
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
            return View(symptom);
        }

        // GET: Symptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Symptom == null)
            {
                return NotFound();
            }

            var symptom = await _context.Symptom
                .FirstOrDefaultAsync(m => m.symptomID == id);
            if (symptom == null)
            {
                return NotFound();
            }

            return View(symptom);
        }

        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Symptom == null)
            {
                return Problem("Entity set 'MediCare2_0Context.Symptom'  is null.");
            }
            var symptom = await _context.Symptom.FindAsync(id);
            if (symptom != null)
            {
                _context.Symptom.Remove(symptom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SymptomExists(int id)
        {
          return _context.Symptom.Any(e => e.symptomID == id);
        }
    }
}
