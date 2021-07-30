using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }
        public int PublirId { get; set; }
        public Publisher Publisher { get; set; }
        public IList<Author> Authors { get; set; }
        public IList<Genre> Genres { get; set; }

    }
}
