using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<Book> GetBookByIdAsync(long id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

        //IEnumerable<Book> GetAllBooks();
        //IEnumerable<Book> GetAllBooksWithDetails();
        //Task<Book> GetBookDetailsAsync(long? id);
        //bool BookExists(long id);
    }
}
