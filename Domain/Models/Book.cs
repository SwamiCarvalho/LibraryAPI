using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Domain.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? OgTitle { get; set; }
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }

        // Navigation Property
        public Publisher Publisher { get; set; }
        public IList<Author> Authors { get; set; }
        public IList<Genre> Genres { get; set; }
    }
}
