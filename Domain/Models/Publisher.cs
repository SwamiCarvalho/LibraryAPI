using System.Collections.Generic;

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
