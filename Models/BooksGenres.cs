using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryAPI.Models
{
    public class BooksGenres
    {
        [ForeignKey("BookId")]
        public long BookId { get; set; }
        [ForeignKey("GenreId")]
        public long GenreId { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
