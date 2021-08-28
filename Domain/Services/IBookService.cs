using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services.Communication;
using LibraryAPI.Resources;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IBookService
    {
        Task<BookResponse> GetAllBooksAsync();
        Task<BookResponse> GetBookByIdAsync(long id, bool full);
        Task<BookResponse> SaveBookAsync(SaveBookResource saveBook);
        Task<BookResponse> UpdateBookAsync(long id, BookDetailsResource bookDetails);
        Task<BookResponse> DeleteBookAsync(long id);
        /*IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksWithDetails();
        Task<Book> GetBookDetailsAsync(long? id);
        bool BookExists(long id);*/
    }
}
