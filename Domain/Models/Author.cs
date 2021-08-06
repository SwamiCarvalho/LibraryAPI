using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Author
    {
        public long Id { get; set; }
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