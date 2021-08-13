using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Services.Communication;
using Supermarket.API.Domain.Repositories;
using System;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {

        public readonly IBookRepository _bookRepository;
        public readonly IUnitOfWork _unitOfWork;

        public BookService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = repositoryWrapper.Books;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.ListAsync();
        }

        public async Task<BookResponse> SaveBookAsync(Book book)
        {
            try
            {
                _bookRepository.AddBook(book);
                await _unitOfWork.CompleteAsync();
                return new BookResponse(book);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<BookResponse> UpdateBookAsync(long id, Book book)
        {
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

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                return new BookResponse($"An error occurred when updating the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> DeleteBookAsync(int id)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);

            if (existingBook == null)
                return new BookResponse("Book not found.");

            try
            {
                _bookRepository.DeleteBook(existingBook);
                await _unitOfWork.CompleteAsync();

                return new BookResponse(existingBook);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BookResponse($"An error occurred when deleting the book: {ex.Message}");
            }
        }

        public async Task<BookResponse> GetBookByIdAsync(long id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
                return new BookResponse("Book not found.");

            return new BookResponse(book);
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
