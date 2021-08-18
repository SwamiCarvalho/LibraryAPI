using System.Collections.Generic;

namespace LibraryAPI.Domain.Models
{
    public class Genre
    {

        public long GenreId { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
