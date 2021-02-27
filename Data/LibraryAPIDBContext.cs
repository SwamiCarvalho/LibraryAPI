using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryAPIDBContext : DbContext
    {
        public LibraryAPIDBContext(DbContextOptions<LibraryAPIDBContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<BooksGenres> BooksGenres { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<Recomendations> Recomendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<BooksAuthors>().ToTable("BooksAuthors");
            modelBuilder.Entity<BooksGenres>().ToTable("BooksGenres");
            modelBuilder.Entity<Librarian>().ToTable("Librarian");
            modelBuilder.Entity<Recomendations>().ToTable("Recomendations");

            modelBuilder.Entity<BooksAuthors>()
                .HasKey(b => new { b.BookId, b.AuthorId });

            modelBuilder.Entity<BooksGenres>()
                .HasKey(b => new { b.BookId, b.GenreId });

        }
    }
}
