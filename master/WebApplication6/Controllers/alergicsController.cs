using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;
using WebApplication6.Pages;

namespace WebApplication6.Controllers
{
    public class alergicsController : Controller
    {
        private static readonly AppDbContext _context = new AppDbContext();
        // GET: alergics
        public static async Task<List<alergic>?> Index()
        {
         
            try
            {

                var exist = await _context.alergicsym.OrderByDescending(x => x).ToListAsync();

                if (exist.Any())
                {
                    return exist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<alergic?> Details(int? id)
        {
            try
            {

                if (id == null || _context.alergicsym == null)
                {
                    return null;
                }
                var agent = await _context.alergicsym.FirstOrDefaultAsync(m => m.drugID == id);
                if (agent == null)
                {
                    return null;
                }
                else
                {
                    return agent;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<alergic?> Create([Bind("drugID,Name,disc")] alergic alergic)
        {
            try
            {
                    _context.alergicsym.Add(alergic);
                    await _context.SaveChangesAsync();
                    return alergic;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<alergic?> Edit(int id, [Bind("drugID,Name,disc")] alergic alergic)
        {
            if (id != alergic.drugID)
            {
                return null;
            }

                try
                {
                    _context.Update(alergic);
                    await _context.SaveChangesAsync();
                    return alergic;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alergicExists(alergic.drugID))
                    {
                        return alergic;
                    }
                    else
                    {
                        throw null;
                    }
                }
                
           
        }
        [ValidateAntiForgeryToken]
        public static async Task<bool> DeleteConfirmed(int id)
        {
            try
            {

                if (_context.alergicsym == null)
                {
                    return false;
                }
                var agent = await _context.alergicsym.FindAsync(id);
                if (agent != null)
                {
                    _context.alergicsym.Remove(agent);
                }

                await _context.SaveChangesAsync();
                return true;
            }catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private static bool alergicExists(int id)
        {
          return (_context.alergicsym?.Any(e => e.drugID == id)).GetValueOrDefault();
        }
    }
}
