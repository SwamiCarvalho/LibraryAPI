using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IBooksRepository : IRepositoryBase<Book>
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksWithDetails();
        Task<Book> GetBookByIdAsync(long id);
        Task<Book> GetBookDetailsAsync(long id);
        bool BookExists(long id);
    }
}
