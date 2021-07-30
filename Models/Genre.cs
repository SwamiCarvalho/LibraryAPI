using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Genre
    {

        public int GenreId { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
