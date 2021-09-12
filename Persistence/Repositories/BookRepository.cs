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
    }
}
