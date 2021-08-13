using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        Task<Book> GetBookByIdAsync(long id);

        //IEnumerable<Book> GetAllBooks();
        //IEnumerable<Book> GetAllBooksWithDetails();
        //Task<Book> GetBookDetailsAsync(long? id);
        //bool BookExists(long id);
    }
}
