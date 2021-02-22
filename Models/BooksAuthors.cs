using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class BooksAuthors
    {
        [ForeignKey("BookId")]
        public long BookId { get; set; }
        [ForeignKey("AuthorId")]
        public long AuthorId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
