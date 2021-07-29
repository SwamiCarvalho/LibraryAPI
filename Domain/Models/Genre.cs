using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Genre
    {

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
