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

        public async Task<SaveBookResponse> SaveBookAsync(Book book)
        {
            try
            {
                await _bookRepository.AddAsync(book);
                await _unitOfWork.CompleteAsync();

                return new SaveBookResponse(book);
            }
            catch (Exception ex)
            {
                return new SaveBookResponse($"An error occurred when saving the category: {ex.Message}");
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
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).ToList();
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            return await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookDetailsAsync(long? id)
        {
            return await FindByCondition(b => b.Id == id).AsQueryable()
                .Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)
                .OrderBy(b => b.Title).FirstOrDefaultAsync();

        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }*/

    }
}
