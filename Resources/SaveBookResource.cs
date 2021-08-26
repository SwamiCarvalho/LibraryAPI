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
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }
        public ICollection<GenreResource> Genres { get; set; } = new List<GenreResource>();
        public ICollection<AuthorResource> Authors { get; set; } = new List<AuthorResource>();
    }
}
