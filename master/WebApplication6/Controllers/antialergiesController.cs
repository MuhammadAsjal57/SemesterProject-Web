using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class antialergiesController : Controller
    {
        private readonly AppDbContext _context;

        public antialergiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: antialergies
        public async Task<IActionResult> Index()
        {
              return _context.antialergy != null ? 
                          View(await _context.antialergy.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.antialergy'  is null.");
        }

        // GET: antialergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.antialergy == null)
            {
                return NotFound();
            }

            var antialergy = await _context.antialergy
                .FirstOrDefaultAsync(m => m.antidrugID == id);
            if (antialergy == null)
            {
                return NotFound();
            }

            return View(antialergy);
        }

        // GET: antialergies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: antialergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("antidrugID,shortName,longName,disc")] antialergy antialergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antialergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antialergy);
        }

        // GET: antialergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.antialergy == null)
            {
                return NotFound();
            }

            var antialergy = await _context.antialergy.FindAsync(id);
            if (antialergy == null)
            {
                return NotFound();
            }
            return View(antialergy);
        }

        // POST: antialergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("antidrugID,shortName,longName,disc")] antialergy antialergy)
        {
            if (id != antialergy.antidrugID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antialergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!antialergyExists(antialergy.antidrugID))
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
            return View(antialergy);
        }

        // GET: antialergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.antialergy == null)
            {
                return NotFound();
            }

            var antialergy = await _context.antialergy
                .FirstOrDefaultAsync(m => m.antidrugID == id);
            if (antialergy == null)
            {
                return NotFound();
            }

            return View(antialergy);
        }

        // POST: antialergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.antialergy == null)
            {
                return Problem("Entity set 'AppDbContext.antialergy'  is null.");
            }
            var antialergy = await _context.antialergy.FindAsync(id);
            if (antialergy != null)
            {
                _context.antialergy.Remove(antialergy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool antialergyExists(int id)
        {
          return (_context.antialergy?.Any(e => e.antidrugID == id)).GetValueOrDefault();
        }
    }
}
