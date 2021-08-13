using LibraryAPI.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<BookResponse> SaveBookAsync(Book book);
        Task<BookResponse> UpdateBookAsync(long id, Book book);
        Task<BookResponse> DeleteBookAsync(int id);
        Task<BookResponse> GetBookByIdAsync(long id);
        /*IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAllBooksWithDetails();
        Task<Book> GetBookDetailsAsync(long? id);
        bool BookExists(long id);*/
    }
}
