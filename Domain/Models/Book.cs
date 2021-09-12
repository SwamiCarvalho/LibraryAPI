using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Book
    {
        [Key]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string? OgTitle { get; set; }
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }

        // Navigation Property
        public Publisher Publisher { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
