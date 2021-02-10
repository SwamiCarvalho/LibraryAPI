using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksAuthors>()
                .HasKey(b => new { b.BookId, b.AuthorId });

            modelBuilder.Entity<BooksGenres>()
                .HasKey(b => new { b.BookId, b.GenreId });
            
            /*/////////////////////// PUBLISHERS ///////////////////////


            // Seed Authors Table
            modelBuilder.Entity<Publisher>()
                .HasData(
                new Publisher { Id = 1, Name = "Dom Quixote", Location = "Alfragide" },
                new Publisher { Id = 2, Name = "Sábado", Location = "Lisboa" }
            );


            /////////////////////// AUTHORS ///////////////////////

            // Seed Authors Table
            var gladwell = new Author { Id=1, FirstName = "Malcom", LastName = "Gladwell" };
            var osho = new Author { Id=2, FirstName = "Osho" };

            modelBuilder.Entity<Author>().HasData(gladwell, osho);


            ///////////////////// GENRES /////////////////////////


            // Seed Authors Table
            var intuition = new Genre { Id = 1, Name = "Intuição" };
            var personalDevelopment = new Genre { Id = 2, Name = "Desenvolvimento Pessoal" };
            var creativity = new Genre { Id = 3, Name = "Criatividade" };

            modelBuilder.Entity<Genre>().HasData(intuition, personalDevelopment, creativity);
 


            ////////////////// BOOKS //////////////////////

            // Seed Books Table
            var blinkBook = new Book
            {
                Id=1,
                Title = "Decidir num piscar de olhos",
                OgTitle = "Blink!",
                PublicationYear = 2009,
                Edition = 4,
                PhysicalDescription = "263 p. ; 24 cm",
                PublisherId = 1
            };


            var intuitionBook = new Book
            {
                Id=2,
                Title = "Intuição",
                OgTitle = "Intuition: knowing beyond logic",
                PublicationYear = 2006,
                PhysicalDescription = "196 p. ; 22 cm",
                PublisherId = 2
            };


            var creativityBook = new Book
            {
                Id=3,
                Title = "Criatividade : libertar as forças interiores",
                PublicationYear = 2006,
                PhysicalDescription = "196 p. ; 22 cm",
                PublisherId = 2
            };


            modelBuilder.Entity<Book>().HasData(blinkBook, intuitionBook, creativityBook);

            ////////// SEED AuthorBook /////////////

            modelBuilder.Entity<BooksAuthors>().HasData(
                new BooksAuthors { BookId = 1, AuthorId = 1 },
                new BooksAuthors { BookId = 2, AuthorId = 2 },
                new BooksAuthors { BookId = 3, AuthorId = 2 });

            ////////// SEED BookGenre /////////////

            modelBuilder.Entity<BooksGenres>().HasData(
                new BooksGenres { BookId = 1, GenreId = 1 },
                new BooksGenres { BookId = 2, GenreId = 2 },
                new BooksGenres { BookId = 2, GenreId = 3 },
                new BooksGenres { BookId = 3, GenreId = 3 });*/

        }
    }
}
