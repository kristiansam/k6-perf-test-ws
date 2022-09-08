using K6.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            _context.Database.EnsureCreated();
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
            _context.Database.EnsureCreated();
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

        // POST: api/HikeRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HikeRating>> PostHikeRating(HikeRating hikeRating)
        {
            _context.Database.EnsureCreated();
            if (_context.HikeRatings == null)
            {
                return Problem("Entity set 'HikeRatingContext.HikeRatings'  is null.");
            }
            _context.HikeRatings.Add(hikeRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHikeRating", new { id = hikeRating.Id }, hikeRating);
        }
    }
}