using LibraryAPI.Domain.Models;
using LibraryAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Persistence
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
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
                Publisher = publishers.Single(p => p.Name == "Dom Quixote"),
                Genres = new List<Genre>(),
                Authors = new List<Author>()
            };

            blink_gladwell.Genres.Add(intuition);
            blink_gladwell.Authors.Add(gladwell);

            var intuition_osho = new Book
            {
                Title = "Intuição",
                OgTitle = "Intuition: knowing beyond logic",
                PublicationYear = 2006,
                PhysicalDescription = "196 p. ; 22 cm",
                Publisher = publishers.Single(p => p.Name == "Sábado"),
                Genres = new List<Genre>(),
                Authors = new List<Author>()
            };

            intuition_osho.Genres.Add(personalDevelopment);
            intuition_osho.Genres.Add(creativity);
            intuition_osho.Authors.Add(osho);


            var creativity_osho = new Book
            {
                Title = "Criatividade : libertar as forças interiores",
                PublicationYear = 2006,
                Genres = new List<Genre>(),
                Authors = new List<Author>()
            };

            creativity_osho.Genres.Add(creativity);
            creativity_osho.Authors.Add(osho);

            var piadas_999_secas = new Book
            {
                Title = "999 + 1 Piadas Ainda Mais Secas",
                PublicationYear = 2006,
                Genres = new List<Genre>(),
                Authors = new List<Author>()
            };

            piadas_999_secas.Genres.Add(new Genre {Name = "Anedotas"});
            piadas_999_secas.Authors.Add(new Author {FirstName = "Pedro", LastName="Pinto" });
            piadas_999_secas.Authors.Add(new Author {FirstName = "Gonçalo", LastName="Castro" });
            piadas_999_secas.Authors.Add(new Author {FirstName = "João", LastName="Ramalhinho" });

            context.Books.AddRange(blink_gladwell, intuition_osho, creativity_osho, piadas_999_secas);
            context.SaveChanges();

        }
    }
}

