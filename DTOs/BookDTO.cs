using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.DTOs
{
    public class BookDTO
    {

        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        [DisplayName("Physical Description")]
        public string Genres { get; set; }
    }
}
