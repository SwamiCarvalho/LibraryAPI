using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        /*IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksWithDetails();
        Task<Book> GetBookByIdAsync(long id);
        Task<Book> GetBookDetailsAsync(long? id);
        bool BookExists(long id);*/
    }
}
