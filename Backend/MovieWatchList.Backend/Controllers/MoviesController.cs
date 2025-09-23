using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchList.Backend.Data;
using MovieWatchList.Backend.Models;

namespace MovieWatchList.Backend.Controllers;

[Route("movies")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    // GET /movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    // GET /movies/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        return movie;
    }

    // POST /movies
    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }

    // PUT /movies/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie movie)
    {
        if (id != movie.Id) return BadRequest();
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(new
        {
            Id = movie.Id,
            Message = $"The movie '{movie.Title}' is updated successfully"
        });
    }

    // DELETE /movies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return Ok(new
        {
            Id = id,
            Message = $"The movie '{movie.Title}' was deleted successfully"
        });
    }
}
