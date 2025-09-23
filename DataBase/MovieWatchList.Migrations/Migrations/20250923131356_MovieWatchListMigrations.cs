using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieWatchList.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class MovieWatchListMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    Watched = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "ImageUrl", "Rating", "ReleaseYear", "Title", "Watched" },
                values: new object[,]
                {
                    { 1, "A mind-bending thriller about dreams within dreams.", "Christopher Nolan", "Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", 9.0, 2010, "Inception", false },
                    { 2, "Batman fights crime in Gotham City.", "Christopher Nolan", "Action", "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg", 9.5, 2008, "The Dark Knight", true },
                    { 3, "A team of explorers travel through a wormhole in space.", "Christopher Nolan", "Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", 8.8000000000000007, 2014, "Interstellar", false },
                    { 4, "A hacker discovers the reality is a simulation.", "Lana Wachowski", "Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/d/db/The_Matrix.png", 9.0, 1999, "The Matrix", true },
                    { 5, "The Avengers assemble to undo Thanos' actions.", "Anthony Russo", "Action", "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", 8.4000000000000004, 2019, "Avengers: Endgame", false },
                    { 6, "The aging patriarch of an organized crime dynasty transfers control to his son.", "Francis Ford Coppola", "Crime", "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg", 9.1999999999999993, 1972, "The Godfather", true },
                    { 7, "The lives of two mob hitmen, a boxer, and others intertwine.", "Quentin Tarantino", "Crime", "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg", 8.9000000000000004, 1994, "Pulp Fiction", false },
                    { 8, "An insomniac office worker forms an underground fight club.", "David Fincher", "Drama", "https://upload.wikimedia.org/wikipedia/en/f/fc/Fight_Club_poster.jpg", 8.8000000000000007, 1999, "Fight Club", true },
                    { 9, "The life story of Forrest Gump, a man with a low IQ.", "Robert Zemeckis", "Drama", "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg", 8.6999999999999993, 1994, "Forrest Gump", false },
                    { 10, "Two imprisoned men bond over years, finding hope and redemption.", "Frank Darabont", "Drama", "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg", 9.3000000000000007, 1994, "The Shawshank Redemption", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
