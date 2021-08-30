using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Publisher
    {
        [Key]
        public long PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [DisplayFormat(NullDisplayText = "No books")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
