using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using K6.Api.Models;

namespace K6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HikeRatingsController : ControllerBase
    {
        private readonly HikeRatingContext _context;

        public HikeRatingsController(HikeRatingContext context)
        {
            _context = context;
        }

        // GET: api/HikeRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HikeRating>>> GetHikeRatings()
        {
          if (_context.HikeRatings == null)
          {
              return NotFound();
          }
            return await _context.HikeRatings.ToListAsync();
        }

        // GET: api/HikeRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HikeRating>> GetHikeRating(int id)
        {
          if (_context.HikeRatings == null)
          {
              return NotFound();
          }
            var hikeRating = await _context.HikeRatings.FindAsync(id);

            if (hikeRating == null)
            {
                return NotFound();
            }

            return hikeRating;
        }

        // PUT: api/HikeRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHikeRating(int id, HikeRating hikeRating)
        {
            if (id != hikeRating.Id)
            {
                return BadRequest();
            }

            _context.Entry(hikeRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HikeRatingExists(id))
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

        // POST: api/HikeRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HikeRating>> PostHikeRating(HikeRating hikeRating)
        {
          if (_context.HikeRatings == null)
          {
              return Problem("Entity set 'HikeRatingContext.HikeRatings'  is null.");
          }
            _context.HikeRatings.Add(hikeRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHikeRating", new { id = hikeRating.Id }, hikeRating);
        }

        // DELETE: api/HikeRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHikeRating(int id)
        {
            if (_context.HikeRatings == null)
            {
                return NotFound();
            }
            var hikeRating = await _context.HikeRatings.FindAsync(id);
            if (hikeRating == null)
            {
                return NotFound();
            }

            _context.HikeRatings.Remove(hikeRating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HikeRatingExists(int id)
        {
            return (_context.HikeRatings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
