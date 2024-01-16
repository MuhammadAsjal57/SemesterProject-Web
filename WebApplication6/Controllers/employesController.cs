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
    public class employesController : Controller
    {
        private readonly AppDbContext _context;

        public employesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: employes
        public async Task<IActionResult> Index()
        {
              return _context.employes != null ? 
                          View(await _context.employes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.employes'  is null.");
        }

        // GET: employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employes == null)
            {
                return NotFound();
            }

            var employe = await _context.employes
                .FirstOrDefaultAsync(m => m.empID == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: employes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empID,empName,date,Gender,Email,PhoneNumber,datejoin,dept,designationn")] employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employe);
        }

        // GET: employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employes == null)
            {
                return NotFound();
            }

            var employe = await _context.employes.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empID,empName,date,Gender,Email,PhoneNumber,datejoin,dept,designationn")] employe employe)
        {
            if (id != employe.empID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeExists(employe.empID))
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
            return View(employe);
        }

        // GET: employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employes == null)
            {
                return NotFound();
            }

            var employe = await _context.employes
                .FirstOrDefaultAsync(m => m.empID == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employes == null)
            {
                return Problem("Entity set 'AppDbContext.employes'  is null.");
            }
            var employe = await _context.employes.FindAsync(id);
            if (employe != null)
            {
                _context.employes.Remove(employe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeExists(int id)
        {
          return (_context.employes?.Any(e => e.empID == id)).GetValueOrDefault();
        }
    }
}
