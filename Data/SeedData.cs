using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LibraryAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(LibraryAPIDBContext context)
        {
            // Automatically creates the database
            context.Database.EnsureCreated();

            /////////////////////// PUBLISHERS ///////////////////////

            // Look for any Publishers.
            if (context.Publishers.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Publisher Table
            var publishers = new Publisher[]
            {
                new Publisher { Name = "Dom Quixote", Location = "Alfragide" },
                new Publisher { Name = "Sábado", Location = "Lisboa" }
            };

            foreach (Publisher publisher in publishers)
            {
                context.Publishers.Add(publisher);
            }
            context.SaveChanges();


            /////////////////////// AUTHORS ///////////////////////

            // Look for any Authors.
            if (context.Authors.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Authors Table
            var gladwell = new Author { FirstName = "Malcom", LastName = "Gladwell" };
            var osho = new Author { FirstName = "Osho" };
            context.Authors.AddRange(gladwell, osho);
            context.SaveChanges();

            ///////////////////// GENRES /////////////////////////

            // Look for any Genres.
            if (context.Genres.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Genres Table
            var intuition = new Genre { Name = "Intuição" };
            var personalDevelopment = new Genre { Name = "Desenvolvimento Pessoal" };
            var creativity = new Genre { Name = "Criatividade" };
            context.Genres.AddRange(intuition, personalDevelopment, creativity);
            context.SaveChanges();


            ////////////////// BOOKS //////////////////////

            // Look for any Books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }


            // Seed Books Table
            var blink_gladwell = new Book
            {
                Title = "Decidir num piscar de olhos",
                OgTitle = "Blink!",
                PublicationYear = 2009,
                Edition = 4,
                PhysicalDescription = "263 p. ; 24 cm",
                PublisherId = publishers.Single(p => p.Name == "Dom Quixote").Id
            };

            var intuition_osho = new Book
            {
                Title = "Intuição",
                OgTitle = "Intuition: knowing beyond logic",
                PublicationYear = 2006,
                PhysicalDescription = "196 p. ; 22 cm",
                PublisherId = publishers.Single(p => p.Name == "Sábado").Id
            };

            var creativity_osho = new Book
            {
                Title = "Criatividade : libertar as forças interiores",
                PublicationYear = 2006
            };

            context.Books.AddRange(blink_gladwell, intuition_osho, creativity_osho);
            context.SaveChanges();

            ////////// SEED AuthorBook /////////////

            // Look for any Books.
            if (context.BooksAuthors.Any())
            {
                return;   // DB has been seeded
            }

            var booksAuthors = new BooksAuthors[]
            {
                new BooksAuthors { BookId = blink_gladwell.Id, AuthorId = gladwell.Id },
                new BooksAuthors { BookId = intuition_osho.Id, AuthorId = osho.Id },
                new BooksAuthors { BookId = creativity_osho.Id, AuthorId = osho.Id }
            };

            /*foreach (BooksAuthors bookAuthor in booksAuthors)
            {
                var booksAuthorsInDB = context.BooksAuthors.Where(
                    b =>
                        b.Author.Id == bookAuthor.AuthorId &&
                        b.Book.Id == bookAuthor.BookId);

                if (booksAuthorsInDB == null)
                {
                    context.BooksAuthors.Add(bookAuthor);
                }
                
            }*/
            foreach (BooksAuthors bookAuthor in booksAuthors)
            {
                context.BooksAuthors.Add(bookAuthor);
            }
            context.SaveChanges();

            ////////// SEED BookGenre /////////////

            // Look for any Books.
            if (context.BooksGenres.Any())
            {
                return;   // DB has been seeded
            }

            var booksGenres = new BooksGenres[]
            {
                new BooksGenres { BookId = blink_gladwell.Id, GenreId = intuition.Id },
                new BooksGenres { BookId = intuition_osho.Id, GenreId = personalDevelopment.Id },
                new BooksGenres { BookId = intuition_osho.Id, GenreId = creativity.Id },
                new BooksGenres { BookId = creativity_osho.Id, GenreId = creativity.Id }
            };

            foreach (BooksGenres bookGenres in booksGenres)
            {
                context.BooksGenres.Add(bookGenres);
            }
            context.SaveChanges();
            /*foreach (BooksGenres bookGenres in booksGenres)
            {
                var booksGenresInDB = context.BooksGenres.Where(
                    b =>
                        b.Genre.Id == bookGenres.GenreId &&
                        b.Book.Id == bookGenres.BookId);

                if (booksGenresInDB == null)
                {
                    context.BooksGenres.Add(bookGenres);
                }
            }*/

        }
    }
}

