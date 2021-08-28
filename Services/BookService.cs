using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LibraryAPI.Domain.Services.Communication;
using AutoMapper;
using LibraryAPI.Resources;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {

        public readonly IBookRepository _bookRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = repositoryWrapper.Books;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookResponse> GetAllBooksAsync()
        {
            var books = await _bookRepository.ListAsync();

            if (books == null)
                return new BookResponse("Books not found.");

            var booksResource = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);

            return new BookResponse(booksResource);
        }

        public async Task<BookResponse> GetBookByIdAsync(long id, bool full)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
                return new BookResponse("Book not found.");

            /*if (full is true)
            {
                var bookResource = _mapper.Map<Book, BookDetailsResource>(book);
            }
            else
            {*/
                
            var bookResource = _mapper.Map<Book, BookDetailsResource>(book);
            //}

            return new BookResponse(bookResource);  
        }

        public async Task<BookResponse> SaveBookAsync(SaveBookResource newBook)
        {
            try
            {
                var book = _mapper.Map<SaveBookResource, Book>(newBook);
                _bookRepository.AddBook(book);
                await _unitOfWork.CompleteAsync();

                var bookResource = _mapper.Map<Book, BookResource>(book);

                return new BookResponse(bookResource);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<BookResponse> UpdateBookAsync(long id, BookDetailsResource bookDetails)
        {
            var book = _mapper.Map<BookDetailsResource, Book>(bookDetails);

            var existingBook = await _bookRepository.GetBookByIdAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            existingBook.Title = book.Title;
            existingBook.OgTitle = book.OgTitle;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.Edition = book.Edition;
            existingBook.Notes = book.Notes;
            existingBook.PhysicalDescription = book.PhysicalDescription;
            existingBook.Publisher = book.Publisher;
            existingBook.Authors = book.Authors;
            existingBook.Genres = book.Genres;

            try
            {
                _bookRepository.UpdateBook(existingBook);
                await _unitOfWork.CompleteAsync();

                var bookResource = _mapper.Map<Book, BookResource>(existingBook);

                return new BookResponse(bookResource);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when updating the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> DeleteBookAsync(long id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            try
            {
                _bookRepository.DeleteBook(existingBook);
                await _unitOfWork.CompleteAsync();

                var bookResource = _mapper.Map<Book, BookResource>(existingBook);

                return new BookResponse(bookResource);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when deleting the book: {ex.Message}");
            }
        }

        /*public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(b => b.Title);
        }

        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            return FindAll()
                .Include(b => b.BooksBooks)
                    .ThenInclude(bg => bg.Book)
                .Include(b => b.BooksBooks)
                    .ThenInclude(ba => ba.Book)
                .OrderBy(b => b.Title).ToList();
        }

        public async Task<Book> GetBookDetailsAsync(long? id)
        {
            return await FindByCondition(b => b.Id == id).AsQueryable()
                .Include(b => b.BooksBooks)
                    .ThenInclude(bg => bg.Book)
                .Include(b => b.BooksBooks)
                    .ThenInclude(ba => ba.Book)
                .OrderBy(b => b.Title).FirstOrDefaultAsync();

        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }*/

    }
}
