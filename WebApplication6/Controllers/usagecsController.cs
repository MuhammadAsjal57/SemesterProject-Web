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
    public class usagecsController : Controller
    {
        private readonly AppDbContext _context;

        public usagecsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: usagecs
        public async Task<IActionResult> Index()
        {
              return _context.usages != null ? 
                          View(await _context.usages.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.usages'  is null.");
        }

        // GET: usagecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usages == null)
            {
                return NotFound();
            }

            var usagecs = await _context.usages
                .FirstOrDefaultAsync(m => m.drugcondID == id);
            if (usagecs == null)
            {
                return NotFound();
            }

            return View(usagecs);
        }

        // GET: usagecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: usagecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("drugcondID,disc,otherdetails")] usagecs usagecs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usagecs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usagecs);
        }

        // GET: usagecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usages == null)
            {
                return NotFound();
            }

            var usagecs = await _context.usages.FindAsync(id);
            if (usagecs == null)
            {
                return NotFound();
            }
            return View(usagecs);
        }

        // POST: usagecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("drugcondID,disc,otherdetails")] usagecs usagecs)
        {
            if (id != usagecs.drugcondID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usagecs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usagecsExists(usagecs.drugcondID))
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
            return View(usagecs);
        }

        // GET: usagecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usages == null)
            {
                return NotFound();
            }

            var usagecs = await _context.usages
                .FirstOrDefaultAsync(m => m.drugcondID == id);
            if (usagecs == null)
            {
                return NotFound();
            }

            return View(usagecs);
        }

        // POST: usagecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usages == null)
            {
                return Problem("Entity set 'AppDbContext.usages'  is null.");
            }
            var usagecs = await _context.usages.FindAsync(id);
            if (usagecs != null)
            {
                _context.usages.Remove(usagecs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool usagecsExists(int id)
        {
          return (_context.usages?.Any(e => e.drugcondID == id)).GetValueOrDefault();
        }
    }
}
