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
    public class typeCongesController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        public typeCongesController(ProjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/typeConges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<typeConge>>> GettypeConges()
        {
            return await _context.typeConges.ToListAsync();
        }

        // GET: api/typeConges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<typeConge>> GettypeConge(int id)
        {
            var typeConge = await _context.typeConges.FindAsync(id);

            if (typeConge == null)
            {
                return NotFound();
            }

            return typeConge;
        }

        // PUT: api/typeConges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttypeConge(int id, typeConge typeConge)
        {
            if (id != typeConge.id)
            {
                return BadRequest();
            }

            _context.Entry(typeConge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!typeCongeExists(id))
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

        // POST: api/typeConges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<typeConge>> PosttypeConge(typeConge typeConge)
        {
            _context.typeConges.Add(typeConge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettypeConge", new { id = typeConge.id }, typeConge);
        }

        // DELETE: api/typeConges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetypeConge(int id)
        {
            var typeConge = await _context.typeConges.FindAsync(id);
            if (typeConge == null)
            {
                return NotFound();
            }

            _context.typeConges.Remove(typeConge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool typeCongeExists(int id)
        {
            return _context.typeConges.Any(e => e.id == id);
        }
    }
}
