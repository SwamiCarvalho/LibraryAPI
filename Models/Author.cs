using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Author
    {
        public Author(){ this.Books = new HashSet<Book>(); }
        [Key]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}