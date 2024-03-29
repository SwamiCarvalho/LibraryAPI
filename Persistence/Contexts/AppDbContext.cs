﻿using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        //public DbSet<Librarian> Librarian { get; set; }
        //public DbSet<Recomendations> Recomendations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Author>().HasKey(p => p.AuthorId);
            modelBuilder.Entity<Author>().Property(p => p.AuthorId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Author>().Property(p => p.LastName).HasMaxLength(20);

            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Genre>().HasKey(p => p.GenreId);
            modelBuilder.Entity<Genre>().Property(p => p.GenreId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().HasKey(p => p.BookId);
            modelBuilder.Entity<Book>().Property(p => p.BookId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.OgTitle);
            modelBuilder.Entity<Book>().Property(p => p.PublicationYear).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.Edition);
            modelBuilder.Entity<Book>().Property(p => p.Notes);
            modelBuilder.Entity<Book>().Property(p => p.PhysicalDescription);

            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Publisher>().HasKey(p => p.PublisherId);
            modelBuilder.Entity<Publisher>().Property(p => p.PublisherId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Publisher>().Property(p => p.Name);
            modelBuilder.Entity<Publisher>().Property(p => p.Location);


            //modelBuilder.Entity<Librarian>().ToTable("Librarian");
            //modelBuilder.Entity<Recomendations>().ToTable("Recomendations");

        }
    }
}
