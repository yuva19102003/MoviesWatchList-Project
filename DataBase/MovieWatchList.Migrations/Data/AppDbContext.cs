using Microsoft.EntityFrameworkCore;
using MovieWatchList.Migrations.Models;
using dotenv.net;
using System;

namespace MovieWatchList.Migrations.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Load .env file
            DotEnv.Load();

            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string db = Environment.GetEnvironmentVariable("DB_NAME") ?? "moviesdb";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            string pass = Environment.GetEnvironmentVariable("DB_PASS") ?? "password";

            string connectionString = $"Host={host};Database={db};Username={user};Password={pass}";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Genre).HasMaxLength(50);
                entity.Property(e => e.Director).HasMaxLength(100);
                entity.Property(e => e.ReleaseYear);
                entity.Property(e => e.Watched);
                entity.Property(e => e.Rating);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            // --- Seed Data with explicit Ids ---
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Director = "Christopher Nolan", ReleaseYear = 2010, Watched = false, Rating = 9.0, Description = "A mind-bending thriller about dreams within dreams.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg" },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", Director = "Christopher Nolan", ReleaseYear = 2008, Watched = true, Rating = 9.5, Description = "Batman fights crime in Gotham City.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg" },
                new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", Director = "Christopher Nolan", ReleaseYear = 2014, Watched = false, Rating = 8.8, Description = "A team of explorers travel through a wormhole in space.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg" },
                new Movie { Id = 4, Title = "The Matrix", Genre = "Sci-Fi", Director = "Lana Wachowski", ReleaseYear = 1999, Watched = true, Rating = 9.0, Description = "A hacker discovers the reality is a simulation.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/db/The_Matrix.png" },
                new Movie { Id = 5, Title = "Avengers: Endgame", Genre = "Action", Director = "Anthony Russo", ReleaseYear = 2019, Watched = false, Rating = 8.4, Description = "The Avengers assemble to undo Thanos' actions.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg" },
                new Movie { Id = 6, Title = "The Godfather", Genre = "Crime", Director = "Francis Ford Coppola", ReleaseYear = 1972, Watched = true, Rating = 9.2, Description = "The aging patriarch of an organized crime dynasty transfers control to his son.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg" },
                new Movie { Id = 7, Title = "Pulp Fiction", Genre = "Crime", Director = "Quentin Tarantino", ReleaseYear = 1994, Watched = false, Rating = 8.9, Description = "The lives of two mob hitmen, a boxer, and others intertwine.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg" },
                new Movie { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher", ReleaseYear = 1999, Watched = true, Rating = 8.8, Description = "An insomniac office worker forms an underground fight club.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/Fight_Club_poster.jpg" },
                new Movie { Id = 9, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis", ReleaseYear = 1994, Watched = false, Rating = 8.7, Description = "The life story of Forrest Gump, a man with a low IQ.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg" },
                new Movie { Id = 10, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont", ReleaseYear = 1994, Watched = true, Rating = 9.3, Description = "Two imprisoned men bond over years, finding hope and redemption.", ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg" }
            );
        }
    }
}
