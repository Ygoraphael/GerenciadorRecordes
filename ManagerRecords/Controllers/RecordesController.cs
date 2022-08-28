using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagerRecords.Data;
using ManagerRecords.Model;

namespace ManagerRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecordesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Recordes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recordes>>> GetRecordes()
        {
            if (_context.Recordes == null)
            {
                return NotFound();
            }
            return await _context.Recordes.ToListAsync();
        }

        // GET: api/Recordes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recordes>> GetRecordes(int id)
        {
            if (_context.Recordes == null)
            {
                return NotFound();
            }
            var recordes = await _context.Recordes.FindAsync(id);

            if (recordes == null)
            {
                return NotFound();
            }

            return recordes;
        }

        // PUT: api/Recordes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordes(int id, RedordeDTO recordes)
        {
            var rec = new Recordes
            {
                Id = id,
                UserName = recordes.UserName,
                Number = recordes.Number
            };

            _context.Entry(rec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordesExists(id))
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

        // POST: api/Recordes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recordes>> PostRecordes(RedordeDTO recordes)
        {
            if (_context.Recordes == null)
            {
                return Problem("Entity set 'AppDbContext.Recordes'  is null.");
            }
            var rec = new Recordes
            {
                UserName = recordes.UserName,
                Number = recordes.Number
            };
            _context.Recordes.Add(rec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecordes", new { id = rec.Id }, recordes);
        }

        // DELETE: api/Recordes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordes(int id)
        {
            if (_context.Recordes == null)
            {
                return NotFound();
            }
            var recordes = await _context.Recordes.FindAsync(id);
            if (recordes == null)
            {
                return NotFound();
            }

            _context.Recordes.Remove(recordes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordesExists(int id)
        {
            return (_context.Recordes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
