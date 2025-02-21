using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Adams.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int? MovieID { get; set; }

        
        public string? Title { get; set; }

        public int? Year { get; set; }

        public bool? Edited { get; set; }  // Nullable but required

        public bool? CopiedToPlex { get; set; } // Add this field

        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        
        public string? Director { get; set; }

        
        public string? Rating { get; set; }

        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
