using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Domain
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key for the database

        [MaxLength(255)]
        public string? MovieName { get; set; } // Nullable to handle missing data

        public int? ReleaseYear { get; set; } // Nullable to handle missing data

        public int? Duration { get; set; } // Nullable to handle missing data

        public double? ImdbRating { get; set; } // Nullable to handle missing data

        public double? Metascore { get; set; } // Nullable to handle missing data

        public int? Votes { get; set; } // Nullable to handle missing data

        [MaxLength(255)]
        public string? Genre { get; set; } // Nullable to handle missing data

        [MaxLength(255)]
        public string? Director { get; set; } // Nullable to handle missing data

        [MaxLength(255)]
        public string? Cast { get; set; } // Nullable to handle missing data

        [MaxLength(50)]
        public string? Gross { get; set; } // Nullable to handle missing data
    }
}
