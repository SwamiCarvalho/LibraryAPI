using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IBooksRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(long id);
        bool BookExists(long id);
    }
}
