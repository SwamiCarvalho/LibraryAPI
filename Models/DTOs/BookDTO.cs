using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryAPI.Models.DTOs
{
    public class BookDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
