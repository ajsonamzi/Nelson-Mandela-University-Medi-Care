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
    public class DrugsController : Controller
    {
        private readonly MediCare2_0Context _context;

        public DrugsController(MediCare2_0Context context)
        {
            _context = context;
        }

        // GET: Drugs
        public async Task<IActionResult> Index()
        {
            var mediCare2_0Context = _context.Drug.Include(d => d.Alternatives).Include(d => d.Companies).Include(d => d.Contraindications).Include(d => d.DrugAdmins).Include(d => d.Phases).Include(d => d.Schedules).Include(d => d.SideEffects).Include(d => d.Symptoms);
            return View(await mediCare2_0Context.ToListAsync());
        }

        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drug == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug
                .Include(d => d.Alternatives)
                .Include(d => d.Companies)
                .Include(d => d.Contraindications)
                .Include(d => d.DrugAdmins)
                .Include(d => d.Phases)
                .Include(d => d.Schedules)
                .Include(d => d.SideEffects)
                .Include(d => d.Symptoms)
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // GET: Drugs/Create
        public IActionResult Create()
        {
            ViewData["alternativeID"] = new SelectList(_context.Alternative, "alternativeID", "alternativeName");
            ViewData["companyID"] = new SelectList(_context.Company, "companyID", "companyName");
            ViewData["contraindicationID"] = new SelectList(_context.Contraindiction, "contraindicationID", "contraindicationName");
            ViewData["drugAdminID"] = new SelectList(_context.DrugAdmin, "drugAdminID", "adminType");
            ViewData["phaseID"] = new SelectList(_context.Phase, "phaseID", "phaseStage");
            ViewData["scheduleID"] = new SelectList(_context.Schedule, "scheduleID", "scheduleNumber");
            ViewData["sideEffectID"] = new SelectList(_context.SideEffect, "sideEffectID", "sideEffectName");
            ViewData["symptomID"] = new SelectList(_context.Symptom, "symptomID", "symptomName");
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drugID,drugName,description,dosage,dateFirstManufactured,drugAdminID,sideEffectID,symptomID,companyID,phaseID,alternativeID,contraindicationID,scheduleID")] Drug drug)
        {
            
                _context.Add(drug);
               

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
   
        }

        // GET: Drugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drug == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            ViewData["alternativeID"] = new SelectList(_context.Alternative, "alternativeID", "alternativeName");
            ViewData["companyID"] = new SelectList(_context.Company, "companyID", "companyName");
            ViewData["contraindicationID"] = new SelectList(_context.Contraindiction, "contraindicationID", "contraindicationName");
            ViewData["drugAdminID"] = new SelectList(_context.DrugAdmin, "drugAdminID", "adminType");
            ViewData["phaseID"] = new SelectList(_context.Phase, "phaseID", "phaseStage");
            ViewData["scheduleID"] = new SelectList(_context.Schedule, "scheduleID", "scheduleNumber");
            ViewData["sideEffectID"] = new SelectList(_context.SideEffect, "sideEffectID", "sideEffectName");
            ViewData["symptomID"] = new SelectList(_context.Symptom, "symptomID", "symptomName");
            return View(drug);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drugID,drugName,description,dosage,dateFirstManufactured,drugAdminID,sideEffectID,symptomID,companyID,phaseID,alternativeID,contraindicationID,scheduleID")] Drug drug)
        {
            if (id != drug.drugID)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(drug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugExists(drug.drugID))
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

        // GET: Drugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drug == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug
                .Include(d => d.Alternatives)
                .Include(d => d.Companies)
                .Include(d => d.Contraindications)
                .Include(d => d.DrugAdmins)
                .Include(d => d.Phases)
                .Include(d => d.Schedules)
                .Include(d => d.SideEffects)
                .Include(d => d.Symptoms)
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drug == null)
            {
                return Problem("Entity set 'MediCare2_0Context.Drug'  is null.");
            }
            var drug = await _context.Drug.FindAsync(id);
            if (drug != null)
            {
                _context.Drug.Remove(drug);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugExists(int id)
        {
          return _context.Drug.Any(e => e.drugID == id);
        }
    }
}
