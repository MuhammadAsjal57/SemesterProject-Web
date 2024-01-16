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
    public class agentsController : Controller
    {
        private readonly AppDbContext _context;

        public agentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: agents
        public async Task<IActionResult> Index()
        {
              return _context.agent != null ? 
                          View(await _context.agent.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.agent'  is null.");
        }

        // GET: agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.agent == null)
            {
                return NotFound();
            }

            var agent = await _context.agent
                .FirstOrDefaultAsync(m => m.reactionID == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reactionID,shortName,longName,disc")] agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.agent == null)
            {
                return NotFound();
            }

            var agent = await _context.agent.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reactionID,shortName,longName,disc")] agent agent)
        {
            if (id != agent.reactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!agentExists(agent.reactionID))
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
            return View(agent);
        }

        // GET: agents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.agent == null)
            {
                return NotFound();
            }

            var agent = await _context.agent
                .FirstOrDefaultAsync(m => m.reactionID == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.agent == null)
            {
                return Problem("Entity set 'AppDbContext.agent'  is null.");
            }
            var agent = await _context.agent.FindAsync(id);
            if (agent != null)
            {
                _context.agent.Remove(agent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool agentExists(int id)
        {
          return (_context.agent?.Any(e => e.reactionID == id)).GetValueOrDefault();
        }
    }
}
