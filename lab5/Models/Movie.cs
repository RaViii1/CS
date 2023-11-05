using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [UIHint("LongText")]
        public string Description { get; set; }
        
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        [UIHint("Stars")]
        public int Rating { get; set; }
        [UIHint("TrailerLink")]
        public string TrailerLink { get; set; }
    }
}