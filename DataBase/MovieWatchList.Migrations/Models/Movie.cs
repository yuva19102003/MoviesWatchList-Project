using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieWatchList.Migrations.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // ✅ Auto-increment in PostgreSQL
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [MaxLength(100)]
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public bool Watched { get; set; }
        public double Rating { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }
    }
}
