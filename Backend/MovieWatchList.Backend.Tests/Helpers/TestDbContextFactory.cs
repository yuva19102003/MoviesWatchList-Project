using Microsoft.EntityFrameworkCore;
using MovieWatchList.Backend.Data;
using MovieWatchList.Backend.Models;

namespace MovieWatchList.Backend.Tests.Helpers
{
    public static class TestDbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            // Seed initial data
            context.Movies.AddRange(
                new Movie { Title = "Inception", Genre = "Sci-Fi", Director = "Christopher Nolan", ReleaseYear = 2010, Watched = false, Rating = 9.0 },
                new Movie { Title = "The Matrix", Genre = "Sci-Fi", Director = "Lana Wachowski", ReleaseYear = 1999, Watched = true, Rating = 9.0 }
            );

            context.SaveChanges();
            return context;
        }
    }
}
