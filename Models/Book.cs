using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        public Book() 
        { 
            this.Genres = new HashSet<Genre>();
            this.Authors = new HashSet<Author>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Original Title")]
        public string OgTitle { get; set; }
        [Required]
        public string PublicationYear { get; set; }
        [Required]
        public int Edition { get; set; }
        public string Notes { get; set; }
        public string PhysicalDescription { get; set; }


        // Foreign Key
        [Required]
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        // Navigation Property
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Author> Authors { get; set; }







    }
}
