using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IBooksAuthorsRepository : IRepositoryBase<BooksAuthors>
    {
        Task<IEnumerable<BooksAuthors>> GetAllBooksAuthorsAsync();

        Task<IEnumerable<BooksAuthors>> GetAllBooksFromAuthorId(long authorId);
    }
}
