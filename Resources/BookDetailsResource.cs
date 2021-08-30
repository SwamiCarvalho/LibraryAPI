using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryAPI.Resources
{
    public class BookDetailsResource
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }
        public ICollection<GenreResource> Genres { get; set; }
        public ICollection<AuthorResource> Authors { get; set; }
    }
}
