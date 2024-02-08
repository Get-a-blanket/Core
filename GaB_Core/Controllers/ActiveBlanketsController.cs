using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaB_Core.ProtectedDbConnector;
using GaB_Core.ProtectedDbConnector.Models;

namespace GaB_Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActiveBlanketsController : ControllerBase
    {
        private readonly ProtectedDbContext _context;

        public ActiveBlanketsController(ProtectedDbContext context)
        {
            _context = context;
        }

        // GET: api/ActiveBlankets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveBlanket>>> GetActiveBlankets()
        {
            return await _context.ActiveBlankets.ToListAsync();
        }

        // GET: api/ActiveBlankets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveBlanket>> GetActiveBlanket(Guid id)
        {
            var activeBlanket = await _context.ActiveBlankets.FindAsync(id);

            if (activeBlanket == null)
            {
                return NotFound();
            }

            return activeBlanket;
        }

        // PUT: api/ActiveBlankets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveBlanket(Guid id, ActiveBlanket activeBlanket)
        {
            if (id != activeBlanket.Id)
            {
                return BadRequest();
            }

            _context.Entry(activeBlanket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveBlanketExists(id))
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

        // POST: api/ActiveBlankets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActiveBlanket>> PostActiveBlanket(ActiveBlanket activeBlanket)
        {
            _context.ActiveBlankets.Add(activeBlanket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActiveBlanket", new { id = activeBlanket.Id }, activeBlanket);
        }

        // DELETE: api/ActiveBlankets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActiveBlanket(Guid id)
        {
            var activeBlanket = await _context.ActiveBlankets.FindAsync(id);
            if (activeBlanket == null)
            {
                return NotFound();
            }

            _context.ActiveBlankets.Remove(activeBlanket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiveBlanketExists(Guid id)
        {
            return _context.ActiveBlankets.Any(e => e.Id == id);
        }
    }
}
