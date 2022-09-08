using Microsoft.EntityFrameworkCore;

namespace K6.Api.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HikeRating>().HasData(
                new HikeRating { Id = 1, HikeName = "Ulriken", Rating = 5 },
                new HikeRating { Id = 2, HikeName = "Midtfjell", Rating = 5 },
                new HikeRating { Id = 3, HikeName = "Trolltunga", Rating = 6 },
                new HikeRating { Id = 4, HikeName = "Himmelbjerget", Rating = 2 }
            );
        }
    }
}