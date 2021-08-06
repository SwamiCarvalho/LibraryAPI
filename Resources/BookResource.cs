using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryAPI.Resources
{
    public class BookResource
    {
        public long Id { get; set; }
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public List<GenreResource> Genres { get; set; }
        public List<AuthorResource> Authors { get; set; }
    }
}
