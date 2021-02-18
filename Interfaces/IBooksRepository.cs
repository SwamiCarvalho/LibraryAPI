using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IBooksRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks();
        Task<Book> GetBookByIdAsync(long id);
        bool BookExists(long id);
    }
}
