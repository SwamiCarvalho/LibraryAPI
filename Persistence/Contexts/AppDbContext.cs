using LibraryAPI.Domain.Models;
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
            modelBuilder.Entity<Author>().HasKey(p => p.Id);
            modelBuilder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Author>().Property(p => p.LastName).HasMaxLength(20);
            //modelBuilder.Entity<Author>().Property(p => p.Books).HasMaxLength(20)

            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Genre>().HasKey(p => p.Id);

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().HasKey(p => p.Id);

            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);

            //modelBuilder.Entity<Librarian>().ToTable("Librarian");
            //modelBuilder.Entity<Recomendations>().ToTable("Recomendations");

        }
    }
}
