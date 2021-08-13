using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Models
{
    public class Publisher
    {
        public long PublisherId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IList<Book> Books { get; set; }
    }
}
