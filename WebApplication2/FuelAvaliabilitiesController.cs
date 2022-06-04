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
    public class FuelAvaliabilitiesController : Controller
    {
        private readonly WebApplication2Context _context;

        public FuelAvaliabilitiesController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: FuelAvaliabilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelAvaliability.ToListAsync());
        }

        // GET: FuelAvaliabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelAvaliability = await _context.FuelAvaliability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelAvaliability == null)
            {
                return NotFound();
            }

            return View(fuelAvaliability);
        }

        // GET: FuelAvaliabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelAvaliabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Avaliable95,Avaliable98,AvaliableDiesel,AvaliableLPG")] FuelAvaliability fuelAvaliability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelAvaliability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelAvaliability);
        }

        // GET: FuelAvaliabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelAvaliability = await _context.FuelAvaliability.FindAsync(id);
            if (fuelAvaliability == null)
            {
                return NotFound();
            }
            return View(fuelAvaliability);
        }

        // POST: FuelAvaliabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Avaliable95,Avaliable98,AvaliableDiesel,AvaliableLPG")] FuelAvaliability fuelAvaliability)
        {
            if (id != fuelAvaliability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelAvaliability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelAvaliabilityExists(fuelAvaliability.Id))
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
            return View(fuelAvaliability);
        }

        // GET: FuelAvaliabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelAvaliability = await _context.FuelAvaliability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelAvaliability == null)
            {
                return NotFound();
            }

            return View(fuelAvaliability);
        }

        // POST: FuelAvaliabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var fuelAvaliability = await _context.FuelAvaliability.FindAsync(id);
            _context.FuelAvaliability.Remove(fuelAvaliability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelAvaliabilityExists(int? id)
        {
            return _context.FuelAvaliability.Any(e => e.Id == id);
        }
    }
}
