using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace PSIM2
{
    public class FuelGradesController : Controller
    {
        private readonly WebApplication2Context _context;

        public FuelGradesController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: FuelGrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelGrade.ToListAsync());
        }

        // GET: FuelGrades/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelGrade = await _context.FuelGrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelGrade == null)
            {
                return NotFound();
            }

            return View(fuelGrade);
        }

        // GET: FuelGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Likes,Dislikes")] FuelGrade fuelGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelGrade);
        }

        // GET: FuelGrades/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelGrade = await _context.FuelGrade.FindAsync(id);
            if (fuelGrade == null)
            {
                return NotFound();
            }
            return View(fuelGrade);
        }

        // POST: FuelGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Likes,Dislikes")] FuelGrade fuelGrade)
        {
            if (id != fuelGrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelGradeExists(fuelGrade.Id))
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
            return View(fuelGrade);
        }

        // GET: FuelGrades/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelGrade = await _context.FuelGrade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelGrade == null)
            {
                return NotFound();
            }

            return View(fuelGrade);
        }

        // POST: FuelGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var fuelGrade = await _context.FuelGrade.FindAsync(id);
            _context.FuelGrade.Remove(fuelGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelGradeExists(long? id)
        {
            return _context.FuelGrade.Any(e => e.Id == id);
        }
    }
}
