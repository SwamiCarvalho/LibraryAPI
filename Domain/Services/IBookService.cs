using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IBookService
    {
        Task<BookResponse> GetAllBooksAsync();
        Task<BookResponse> GetBookByIdAsync(long id);
        Task<BookResponse> SaveBookAsync(Book book);
        Task<BookResponse> UpdateBookAsync(long id, Book book);
        Task<BookResponse> DeleteBookAsync(long id);
        /*IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksWithDetails();
        Task<Book> GetBookDetailsAsync(long? id);
        bool BookExists(long id);*/
    }
}
