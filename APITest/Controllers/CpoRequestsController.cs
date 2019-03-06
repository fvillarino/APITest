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
    public class CpoRequestsController : ControllerBase
    {
        private readonly DB_CLOUDPLAYOUTContext _context;

        public CpoRequestsController(DB_CLOUDPLAYOUTContext context)
        {
            _context = context;
        }

        // GET: api/CpoRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CpoRequest>>> GetCpoRequest()
        {
            return await _context.CpoRequest.ToListAsync();
        }

        // GET: api/CpoRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CpoRequest>> GetCpoRequest(long id)
        {
            var cpoRequest = await _context.CpoRequest.FindAsync(id);

            if (cpoRequest == null)
            {
                return NotFound();
            }

            return cpoRequest;
        }

        // PUT: api/CpoRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpoRequest(long id, CpoRequest cpoRequest)
        {
            if (id != cpoRequest.Idrequest)
            {
                return BadRequest();
            }

            _context.Entry(cpoRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpoRequestExists(id))
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

        // POST: api/CpoRequests
        [HttpPost]
        public async Task<ActionResult<CpoRequest>> PostCpoRequest(CpoRequest cpoRequest)
        {
            _context.CpoRequest.Add(cpoRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpoRequest", new { id = cpoRequest.Idrequest }, cpoRequest);
        }

        // DELETE: api/CpoRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CpoRequest>> DeleteCpoRequest(long id)
        {
            var cpoRequest = await _context.CpoRequest.FindAsync(id);
            if (cpoRequest == null)
            {
                return NotFound();
            }

            _context.CpoRequest.Remove(cpoRequest);
            await _context.SaveChangesAsync();

            return cpoRequest;
        }

        private bool CpoRequestExists(long id)
        {
            return _context.CpoRequest.Any(e => e.Idrequest == id);
        }
    }
}
