using LibraryAPI.Domain.Models;
using System.Collections.Generic;

namespace LibraryAPI.Domain.Services.Communication
{
    public class BookResponse : BaseResponse
    {
        public Book Book { get; private set; }
        public IEnumerable<Book> Books { get; private set; }

        private BookResponse(bool success, string message, Book book, IEnumerable<Book> books) : base(success, message)
        {
            Book = book;
            Books = books;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="book">Saved category.</param>
        /// <returns>Response.</returns>
        public BookResponse(Book book) : this(true, string.Empty, book, null)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BookResponse(string message) : this(false, message, null, null)
        { }

        public BookResponse(IEnumerable<Book> books) : this(true, string.Empty, null, books)
        { }
    }
}