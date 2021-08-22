using LibraryAPI.Domain.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Recomendations
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Observation")]
        public string Text { get; set; }
        [Required]
        [DisplayName("Recomendation Date")]
        public DateTime Date { get; set; }

        [ForeignKey("LibrarianId")]
        public long LibrarianId { get; set; }
        [ForeignKey("BookId")]
        public long BookId { get; set; }
        public virtual Librarian Librarian { get; set; }
        public virtual Book Book { get; set; }
    }
}
