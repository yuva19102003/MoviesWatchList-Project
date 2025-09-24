# 🎬 ASP.NET Core Web API + EF Core + xUnit Testing (InMemory)

---

## 1️⃣ Setup Web API Project

```bash
dotnet new webapi -n MovieWatchList.Backend
cd MovieWatchList.Backend
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

---

## 2️⃣ Define Model

📂 **Models/Movie.cs**

```csharp
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Genre { get; set; } = "";
}
```

---

## 3️⃣ DbContext

📂 **Data/AppDbContext.cs**

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Movie> Movies => Set<Movie>();
}
```

---

## 4️⃣ Controller (CRUD)

📂 **Controllers/MoviesController.cs**

```csharp
[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _ctx;
    public MoviesController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet] public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() =>
        await _ctx.Movies.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id) =>
        await _ctx.Movies.FindAsync(id) is Movie m ? m : NotFound();

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie m)
    {
        _ctx.Movies.Add(m);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { id = m.Id }, m);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie m)
    {
        if (id != m.Id) return BadRequest();
        _ctx.Entry(m).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var m = await _ctx.Movies.FindAsync(id);
        if (m == null) return NotFound();
        _ctx.Movies.Remove(m);
        await _ctx.SaveChangesAsync();
        return NoContent();
    }
}
```

---

## 5️⃣ Register DB in Program.cs

```csharp
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
```

👉 Add PostgreSQL connection string in **appsettings.json**.

---

## 6️⃣ Create Test Project

```bash
cd ..
dotnet new xunit -n MovieWatchList.Backend.Tests
dotnet add MovieWatchList.Backend.Tests reference MovieWatchList.Backend
dotnet add MovieWatchList.Backend.Tests package Microsoft.EntityFrameworkCore.InMemory
```

---

## 7️⃣ Test Helper (InMemory DB)

📂 **TestDb.cs**

```csharp
public static class TestDb
{
    public static AppDbContext Create()
    {
        var opt = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        var ctx = new AppDbContext(opt);
        ctx.Movies.AddRange(new Movie{Title="Inception"}, new Movie{Title="Matrix"});
        ctx.SaveChanges();
        return ctx;
    }
}
```

---

## 8️⃣ Example Tests

📂 **MoviesControllerTests.cs**

```csharp
public class MoviesTests
{
    [Fact]
    public async Task GetMovies_ReturnsAll()
    {
        var c = new MoviesController(TestDb.Create());
        var res = await c.GetMovies();
        Assert.Equal(2, res.Value!.Count());
    }

    [Fact]
    public async Task CreateMovie_AddsOne()
    {
        var ctx = TestDb.Create();
        var c = new MoviesController(ctx);
        await c.CreateMovie(new Movie{Title="Oppenheimer"});
        Assert.Equal(3, ctx.Movies.Count());
    }

    // Similar: GetById, NotFound, Update, Delete
}
```

---

## 9️⃣ Run Tests

```bash
dotnet test
```

✅ Example output:

```
Passed!  Total: 6, Passed: 6, Failed: 0
```

---

# 🚀 Summary

* **Backend** → ASP.NET Core Web API + EF Core + PostgreSQL.
* **CRUD Controller** → GET, POST, PUT, DELETE.
* **Testing** → xUnit + EFCore.InMemory (no DB required).
* **Good Practice** → Fresh DB per test = isolation & reliability.

---

