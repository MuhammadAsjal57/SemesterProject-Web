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
    public class drugsController : Controller
    {
        private readonly AppDbContext _context;

        public drugsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: drugs
        public async Task<IActionResult> Index()
        {
              return _context.drugs != null ? 
                          View(await _context.drugs.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.drugs'  is null.");
        }

        // GET: drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.drugs == null)
            {
                return NotFound();
            }

            var drug = await _context.drugs
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // GET: drugs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drugID,shortName,longName,disc,analyse")] drug drug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drug);
        }

        // GET: drugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.drugs == null)
            {
                return NotFound();
            }

            var drug = await _context.drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        // POST: drugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drugID,shortName,longName,disc,analyse")] drug drug)
        {
            if (id != drug.drugID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!drugExists(drug.drugID))
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
            return View(drug);
        }

        // GET: drugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.drugs == null)
            {
                return NotFound();
            }

            var drug = await _context.drugs
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // POST: drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.drugs == null)
            {
                return Problem("Entity set 'AppDbContext.drugs'  is null.");
            }
            var drug = await _context.drugs.FindAsync(id);
            if (drug != null)
            {
                _context.drugs.Remove(drug);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool drugExists(int id)
        {
          return (_context.drugs?.Any(e => e.drugID == id)).GetValueOrDefault();
        }
    }
}
