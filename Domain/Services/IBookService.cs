using LibraryAPI.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<SaveBookResponse> SaveBookAsync(Book book);
        /* IEnumerable<Book> GetAllBooks();
         IEnumerable<Book> GetAllBooksWithDetails();
         Task<Book> GetBookByIdAsync(long id);
         Task<Book> GetBookDetailsAsync(long? id);
         bool BookExists(long id);*/
    }
}
