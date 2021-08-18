using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LibraryAPI.Persistence.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {

        public  BookRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await FindAll()
                .Include(g => g.Genres)
                .Include(g => g.Authors).ToListAsync();
        }

        public void AddBook(Book book)
        {
            Create(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }
        public void DeleteBook(Book book)
        {
            Delete(book);
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            return await FindByCondition(b => b.BookId == id).FirstOrDefaultAsync();
        }

        /*public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(b => b.Title);
        }

        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            return FindAll()
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).ToList();
        }*/

        /*public async Task<Book> GetBookDetailsAsync(long? id)
        {
            return await FindByCondition(b => b.Id == id).AsQueryable()
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).FirstOrDefaultAsync();

        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }*/

    }
}
