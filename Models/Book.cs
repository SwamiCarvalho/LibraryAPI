using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string? OgTitle { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        public int? Edition { get; set; }
        public string? Notes { get; set; }
        public string? PhysicalDescription { get; set; }

        [ForeignKey("PublisherId")]
        public long? PublisherId { get; set; }
        // Navigation Property
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BooksAuthors> BooksAuthors { get; set; }
        public virtual ICollection<BooksGenres> BooksGenres { get; set; }








    }
}
