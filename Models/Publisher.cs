using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IList<Book> Books { get; set; }
    }
}
