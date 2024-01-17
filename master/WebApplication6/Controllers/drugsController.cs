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
        private static readonly AppDbContext _context=new AppDbContext();

    
        // GET: drugs
        public static async Task<List<drug>?> Index()
        {
              
            try
            {

                var exist = await _context.drugs.OrderByDescending(x => x).ToListAsync();

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

        // GET: drugs/Details/5
        public static async Task<drug?> Details(int? id)
        {
            try
            {
                if (id == null || _context.drugs == null)
                {
                    return null;
                }
                var agent = await _context.drugs.FirstOrDefaultAsync(m => m.drugID == id);
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


        public static async Task<drug?> Create([Bind("drugID,shortName,longName,disc,analyse")] drug drug)
        {
            int lastentry = 0;
            try
            {
                drug.analyse = "";
                _context.drugs.Add(drug);
                lastentry= await _context.SaveChangesAsync();
                if (lastentry>0)
                {
                    return drug;
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
        public static async Task<drug?> Edit(int id, [Bind("drugID,shortName,longName,disc,analyse")] drug drug)
        {
            if (id != drug.drugID)
            {
                return null;
            }
                
            
            
                try
                {
                    _context.Update(drug);
                    await _context.SaveChangesAsync();
                    return drug;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!drugExists(drug.drugID))
                    {
                        return drug;
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

                if (_context.drugs == null)
                {
                    return false;
                }
                var agent = await _context.drugs.FindAsync(id);
                if (agent != null)
                {
                    _context.drugs.Remove(agent);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private static bool drugExists(int id)
        {
          return (_context.drugs?.Any(e => e.drugID == id)).GetValueOrDefault();
        }
    }
}
