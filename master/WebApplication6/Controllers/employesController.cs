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
        private static readonly AppDbContext _context = new AppDbContext();

        // GET: employes
        public static async Task<List<employe>?> Index()
        {
            try
            {

                var exist = await _context.employes.OrderByDescending(x => x).ToListAsync();

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

        // GET: employes/Details/5
        public static async Task<employe?> Details(int? id)
        {
            try
            {

                if (id == null || _context.employes == null)
                {
                    return null;
                }
                var agent = await _context.employes.FirstOrDefaultAsync(m => m.empID == id);
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

        public static async Task<employe?> Create([Bind("empID,empName,date,Gender,Email,PhoneNumber,datejoin,dept,designationn")] employe employe)
        {
            try
            {

                   _context.employes.Add(employe);
                    await _context.SaveChangesAsync();
                    return employe;
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<employe?> Edit(int id, [Bind("empID,empName,date,Gender,Email,PhoneNumber,datejoin,dept,designationn")] employe employe)
        {
            if (id != employe.empID)
            {
                return null;
            }

                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                    return employe;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeExists  (employe.empID))
                    {
                        return employe;
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

                if (_context.employes == null)
                {
                    return false;
                }
                var agent = await _context.employes.FindAsync(id);
                if (agent != null)
                {
                    _context.employes.Remove(agent);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private static bool employeExists(int id)
        {
          return (_context.employes?.Any(e => e.empID == id)).GetValueOrDefault();
        }
    }
}
