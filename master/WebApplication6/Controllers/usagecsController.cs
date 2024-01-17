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
        private static readonly AppDbContext _context = new AppDbContext();

        // GET: usagecs
        public static async Task<List<usagecs>?> Index()
        {
              
            try
            {

                var exist = await _context.usages.OrderByDescending(x => x).ToListAsync();

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

        // GET: usagecs/Details/5
        public static async Task<usagecs?> Details(int? id)
        {
            try
            {

                if (id == null || _context.usages == null)
                {
                    return null;
                }
                var agent = await _context.usages.FirstOrDefaultAsync(m => m.drugcondID == id);
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

        public static async Task<usagecs?> Create([Bind("drugcondID,disc,otherdetails")] usagecs usagecs)
        {
            try
            {


                
                    _context.usages.Add(usagecs);
                    await _context.SaveChangesAsync();
                    return usagecs;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<usagecs?> Edit(int id, [Bind("drugcondID,disc,otherdetails")] usagecs usagecs)
        {

            if (id != usagecs.drugcondID)
            {
                return null;
            }

                try
                {
                    _context.Update(usagecs);
                    await _context.SaveChangesAsync();
                    return usagecs;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usagecsExists(usagecs.drugcondID))
                    {
                        return usagecs;
                    }
                    else
                    {
                        return null;
                    }
                }
        }

        public static async Task<bool> DeleteConfirmed(int id)
        {

            try
            {

                if (_context.usages == null)
                {
                    return false;
                }
                var agent = await _context.usages.FindAsync(id);
                if (agent != null)
                {
                    _context.usages.Remove(agent);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private static bool usagecsExists(int id)
        {
          return (_context.usages?.Any(e => e.drugcondID == id)).GetValueOrDefault();
        }
    }
}
