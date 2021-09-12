using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Genre
    {
        [Key]
        public long GenreId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(NullDisplayText = "No books")]
        public ICollection<Book> Books { get; set; }
    }
}
