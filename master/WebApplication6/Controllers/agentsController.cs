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
        private static readonly AppDbContext _context = new AppDbContext();
        // GET: agents
        public static async Task<List<agent>?> Index()
        {
            try { 

                var exist=await _context.agent.OrderByDescending(x=>x).ToListAsync();
                          
                if(exist.Any())
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
        public static async Task<agent?> Details(int? id)
        {
           
            try
            {

                if (id == null || _context.agent == null)
                {
                    return null;
                }
                var agent = await _context.agent.FirstOrDefaultAsync(m => m.reactionID == id);
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
        public static async Task<agent?> Create([Bind("reactionID,shortName,longName,disc")] agent agent)
        {
            try
            {


                
                    _context.agent.Add(agent);
                    await _context.SaveChangesAsync();
                    return agent;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<agent?> Edit(int id, [Bind("reactionID,shortName,longName,disc")] agent agent)
        {
            if (id != agent.reactionID)
            {
                return null;
            }

            
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                    return agent;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!agentExists(agent.reactionID))
                    {
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }

            
          
            
        }

        public static async Task<bool> Delete(int? id)
        {
            try
            {
                if (id == null || _context.agent == null)
                {
                    return false;
                }

                var agent = await _context.agent
                    .FirstOrDefaultAsync(m => m.reactionID == id);
                if (agent == null)
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex) { }
            {
                return false;
            }
        }

        public static async Task<bool?> DeleteConfirmed(int id)
        {
            if (_context.agent == null)
            {
                return false;
            }
            var agent = await _context.agent.FindAsync(id);
            if (agent != null)
            {
                _context.agent.Remove(agent);
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        private static bool agentExists(int id)
        {
          return (_context.agent?.Any(e => e.reactionID == id)).GetValueOrDefault();
        }
    }
}
