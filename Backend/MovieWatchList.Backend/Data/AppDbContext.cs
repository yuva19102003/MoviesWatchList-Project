using Microsoft.EntityFrameworkCore;
using MovieWatchList.Backend.Models;

namespace MovieWatchList.Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
}
