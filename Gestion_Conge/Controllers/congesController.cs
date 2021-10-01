using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Gestion_Conge.Domain;

namespace Gestion_Conge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class congesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public congesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/conges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<conge>>> Getconges()
        {
            return await _context.conges.ToListAsync();
        }

        // GET: api/conges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<conge>> Getconge(string id)
        {
            var conge = await _context.conges.FindAsync(id);

            if (conge == null)
            {
                return NotFound();
            }

            return conge;
        }

        // PUT: api/conges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putconge(int id, conge conge)
        {
            if (id != conge.id)
            {
                return BadRequest();
            }

            _context.Entry(conge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!congeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/conges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<conge>> Postconge(conge conge)
        {
            _context.conges.Add(conge);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (congeExists(conge.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getconge", new { id = conge.id }, conge);
        }

        // DELETE: api/conges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteconge(string id)
        {
            var conge = await _context.conges.FindAsync(id);
            if (conge == null)
            {
                return NotFound();
            }

            _context.conges.Remove(conge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool congeExists(int id)
        {
            return _context.conges.Any(e => e.id == id);
        }
    }
}
