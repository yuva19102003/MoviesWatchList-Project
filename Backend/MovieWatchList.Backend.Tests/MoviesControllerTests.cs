using Microsoft.AspNetCore.Mvc;
using MovieWatchList.Backend.Controllers;
using MovieWatchList.Backend.Models;
using MovieWatchList.Backend.Tests.Helpers;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWatchList.Backend.Tests
{
    public class TestSummary : IDisposable
    {
        private static int passed = 0;
        private static int total = 0;

        public static void TestPassed(string message)
        {
            total++;
            passed++;
            Console.WriteLine($"{message} = ✅Passed");
        }

        public static void TestFailed(string message)
        {
            total++;
            Console.WriteLine($"{message} = ❌Failed");
        }

        public void Dispose()
        {
            Console.WriteLine($"✅ {passed}/{total} Passed, ❌ {total - passed} Failed");
        }
    }

    public class MoviesControllerTests : IDisposable
    {
        private readonly TestSummary _summary = new TestSummary();

        [Fact]
        public async Task GetMovies_ReturnsAllMovies()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var result = await controller.GetMovies();

                Assert.Equal(2, result.Value!.Count());
                TestSummary.TestPassed("GET /movies");
            }
            catch
            {
                TestSummary.TestFailed("GET /movies");
                throw;
            }
        }

        [Fact]
        public async Task GetMovie_ReturnsCorrectMovie()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var movie = await controller.GetMovie(1);

                Assert.NotNull(movie.Value);
                Assert.Equal("Inception", movie.Value!.Title);
                TestSummary.TestPassed("GET /movies/{id}");
            }
            catch
            {
                TestSummary.TestFailed("GET /movies/{id}");
                throw;
            }
        }

        [Fact]
        public async Task GetMovie_ReturnsNotFound()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var result = await controller.GetMovie(999);

                Assert.IsType<NotFoundResult>(result.Result);
                TestSummary.TestPassed("GET /movies/{invalid-id}");
            }
            catch
            {
                TestSummary.TestFailed("GET /movies/{invalid-id}");
                throw;
            }
        }

        [Fact]
        public async Task CreateMovie_AddsMovie()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var newMovie = new Movie
                {
                    Title = "Oppenheimer",
                    Genre = "Biography",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2023,
                    Watched = false,
                    Rating = 9.1
                };

                var result = await controller.CreateMovie(newMovie);

                Assert.IsType<CreatedAtActionResult>(result.Result);
                Assert.Equal(3, context.Movies.Count());
                TestSummary.TestPassed("POST /movies");
            }
            catch
            {
                TestSummary.TestFailed("POST /movies");
                throw;
            }
        }

        [Fact]
        public async Task UpdateMovie_ChangesMovie()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var movie = context.Movies.First();
                movie.Title = "Inception Updated";

                var result = await controller.UpdateMovie(movie.Id, movie);

                Assert.IsType<NoContentResult>(result);
                Assert.Equal("Inception Updated", context.Movies.Find(movie.Id)!.Title);
                TestSummary.TestPassed("PUT /movies/{id}");
            }
            catch
            {
                TestSummary.TestFailed("PUT /movies/{id}");
                throw;
            }
        }

        [Fact]
        public async Task DeleteMovie_RemovesMovie()
        {
            try
            {
                var context = TestDbContextFactory.Create();
                var controller = new MoviesController(context);

                var movie = context.Movies.First();
                var result = await controller.DeleteMovie(movie.Id);

                Assert.IsType<NoContentResult>(result);
                Assert.Equal(1, context.Movies.Count());
                TestSummary.TestPassed("DELETE /movies/{id}");
            }
            catch
            {
                TestSummary.TestFailed("DELETE /movies/{id}");
                throw;
            }
        }

        public void Dispose()
        {
            _summary.Dispose();
        }
    }
}
