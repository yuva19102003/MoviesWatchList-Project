using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWatchList.Backend.Models;

public class Movie
{
    [Key]   // Marks primary key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto increment
    public int Id { get; set; }

    [Required]  
    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public bool Watched { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
