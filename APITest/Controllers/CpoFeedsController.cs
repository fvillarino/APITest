using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITest.Models;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpoFeedsController : ControllerBase
    {
        private readonly DB_CLOUDPLAYOUTContext _context;

        public CpoFeedsController(DB_CLOUDPLAYOUTContext context)
        {
            _context = context;
        }

        // GET: api/CpoFeeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CpoFeed>>> GetCpoFeed()
        {
            return await _context.CpoFeed.ToListAsync();
        }

        // GET: api/CpoFeeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CpoFeed>> GetCpoFeed(int id)
        {
            var cpoFeed = await _context.CpoFeed.FindAsync(id);

            if (cpoFeed == null)
            {
                return NotFound();
            }

            return cpoFeed;
        }

        // PUT: api/CpoFeeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpoFeed(int id, CpoFeed cpoFeed)
        {
            if (id != cpoFeed.Idfeed)
            {
                return BadRequest();
            }

            _context.Entry(cpoFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpoFeedExists(id))
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

        // POST: api/CpoFeeds
        [HttpPost]
        public async Task<ActionResult<CpoFeed>> PostCpoFeed(CpoFeed cpoFeed)
        {
            _context.CpoFeed.Add(cpoFeed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpoFeed", new { id = cpoFeed.Idfeed }, cpoFeed);
        }

        // DELETE: api/CpoFeeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CpoFeed>> DeleteCpoFeed(int id)
        {
            var cpoFeed = await _context.CpoFeed.FindAsync(id);
            if (cpoFeed == null)
            {
                return NotFound();
            }

            _context.CpoFeed.Remove(cpoFeed);
            await _context.SaveChangesAsync();

            return cpoFeed;
        }

        private bool CpoFeedExists(int id)
        {
            return _context.CpoFeed.Any(e => e.Idfeed == id);
        }
    }
}
