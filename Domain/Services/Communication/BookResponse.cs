using LibraryAPI.Resources;
using System.Collections.Generic;

namespace LibraryAPI.Domain.Services.Communication
{
    public class BookResponse : BaseResponse
    {
        public BookResource Book { get; private set; }
        public BookDetailsResource BookDetails { get; private set; }
        public IEnumerable<BookResource> Books { get; private set; }

        private BookResponse(bool success, string message, BookResource book, BookDetailsResource bookDetails, IEnumerable<BookResource> books) : base(success, message)
        {
            Book = book;
            BookDetails = bookDetails;
            Books = books;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="book">Saved category.</param>
        /// <returns>Response.</returns>
        public BookResponse(BookResource book) : this(true, string.Empty, book, null, null)
        { }

        public BookResponse(BookDetailsResource bookDetails) : this(true, string.Empty, null, bookDetails, null)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BookResponse(string message) : this(false, message, null, null, null)
        { }

        public BookResponse(IEnumerable<BookResource> books) : this(true, string.Empty, null, null, books)
        { }
    }
}