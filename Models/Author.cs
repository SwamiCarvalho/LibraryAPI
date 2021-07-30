using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<Book> Books { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}