using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Resources
{
    public class SaveBookResource
    {
        [Required(ErrorMessage = "Please add the book title.")]
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [Required(ErrorMessage = "Please add the book publication year.")]
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public List<GenreResource> Genres { get; set; }
        public List<AuthorResource> Authors { get; set; }
    }
}
