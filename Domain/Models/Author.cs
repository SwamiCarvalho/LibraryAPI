using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Author
    {
        [Key]
        public long AuthorId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [DisplayFormat(NullDisplayText = "No books")]
        public virtual ICollection<Book> Books { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}