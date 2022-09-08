using Microsoft.EntityFrameworkCore;

namespace K6.Api.Models
{
    public class HikeRatingContext : DbContext
    {
        public HikeRatingContext(DbContextOptions<HikeRatingContext> options) : base(options)
        {

        }

        public DbSet<HikeRating> HikeRatings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}