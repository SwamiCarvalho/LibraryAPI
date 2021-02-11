using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Genre
    {

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
    }
}
