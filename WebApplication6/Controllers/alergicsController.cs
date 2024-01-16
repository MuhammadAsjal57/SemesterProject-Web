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
    public class alergicsController : Controller
    {
        private readonly AppDbContext _context;

        public alergicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: alergics
        public async Task<IActionResult> Index()
        {
              return _context.alergicsym != null ? 
                          View(await _context.alergicsym.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.alergicsym'  is null.");
        }

        // GET: alergics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.alergicsym == null)
            {
                return NotFound();
            }

            var alergic = await _context.alergicsym
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (alergic == null)
            {
                return NotFound();
            }

            return View(alergic);
        }

        // GET: alergics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: alergics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drugID,Name,disc")] alergic alergic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alergic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alergic);
        }

        // GET: alergics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.alergicsym == null)
            {
                return NotFound();
            }

            var alergic = await _context.alergicsym.FindAsync(id);
            if (alergic == null)
            {
                return NotFound();
            }
            return View(alergic);
        }

        // POST: alergics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drugID,Name,disc")] alergic alergic)
        {
            if (id != alergic.drugID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alergic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alergicExists(alergic.drugID))
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
            return View(alergic);
        }

        // GET: alergics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.alergicsym == null)
            {
                return NotFound();
            }

            var alergic = await _context.alergicsym
                .FirstOrDefaultAsync(m => m.drugID == id);
            if (alergic == null)
            {
                return NotFound();
            }

            return View(alergic);
        }

        // POST: alergics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.alergicsym == null)
            {
                return Problem("Entity set 'AppDbContext.alergicsym'  is null.");
            }
            var alergic = await _context.alergicsym.FindAsync(id);
            if (alergic != null)
            {
                _context.alergicsym.Remove(alergic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool alergicExists(int id)
        {
          return (_context.alergicsym?.Any(e => e.drugID == id)).GetValueOrDefault();
        }
    }
}
