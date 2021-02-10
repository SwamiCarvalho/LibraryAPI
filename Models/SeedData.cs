using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryAPIDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryAPIDBContext>>()))
            {

                /////////////////////// PUBLISHERS ///////////////////////

                // Look for any Authors.
                if (context.Publishers.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed Authors Table
                context.Publishers.AddRange(
                    new Publisher { Id = 1, Name = "Dom Quixote", Location = "Alfragide" },
                    new Publisher { Id = 2, Name = "Sábado", Location = "Lisboa" }
                );
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

                // Look for any Books.
                if (context.Genres.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed Authors Table
                var intuition = new Genre { Id = 1, Name = "Intuição" };
                var personalDevelopment = new Genre { Id = 2, Name = "Desenvolvimento Pessoal" };
                var creativity = new Genre { Id = 3, Name = "Criatividade" };
                context.Genres.AddRange(intuition, personalDevelopment, creativity);
                context.SaveChanges();


                ////////////////// BOOKS //////////////////////

                // Look for any Books.
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }


                // Seed Books Table
                var books = new Book[]
                {
                    new Book{
                    Title = "Decidir num piscar de olhos",
                    OgTitle = "Blink!",
                    PublicationYear = 2009,
                    Edition = 4,
                    PhysicalDescription = "263 p. ; 24 cm",
                    PublisherId = 1
                    },

                    new Book{
                    Title = "Intuição",
                    OgTitle = "Intuition: knowing beyond logic",
                    PublicationYear = 2006,
                    PhysicalDescription = "196 p. ; 22 cm",
                    PublisherId = 2
                    },

                    new Book{
                    Title = "Criatividade : libertar as forças interiores",
                    PublicationYear = 2006,
                    PhysicalDescription = "196 p. ; 22 cm",
                    PublisherId = 2
                    }
                };
                
                foreach( Book book in books)
                {
                    context.Books.Add(book);
                }
                context.SaveChanges();

                ////////// SEED AuthorBook /////////////

                var booksauthors = new BooksAuthors[]
                {
                    new BooksAuthors { BookId = 1, AuthorId = 1 },
                    new BooksAuthors { BookId = 2, AuthorId = 2 },
                    new BooksAuthors { BookId = 3, AuthorId = 2 }
                };
                    

                context.SaveChanges();

                ////////// SEED BookGenre /////////////

                context.BooksGenres.AddRange(
                    new BooksGenres { BookId = 1, GenreId = 1 },
                    new BooksGenres { BookId = 2, GenreId = 2 },
                    new BooksGenres { BookId = 2, GenreId = 3 },
                    new BooksGenres { BookId = 3, GenreId = 3 });

                context.SaveChanges();
            }
        }
    }
}