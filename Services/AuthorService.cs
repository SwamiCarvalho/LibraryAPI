using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LibraryAPI.Domain.Services.Communication;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {


        public readonly IAuthorRepository _authorRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AuthorService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _authorRepository = repositoryWrapper.Authors;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorRepository.ListAsync();
        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(long id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
                return new AuthorResponse("Author not found.");

            return new AuthorResponse(author);
        }

        public async Task<AuthorResponse> SaveAuthorAsync(Author author)
        {
            try
            {
                _authorRepository.AddAuthor(author);
                await _unitOfWork.CompleteAsync();

                return new AuthorResponse(author);
            }
            catch (Exception ex)
            {
                return new AuthorResponse($"An error occurred when saving the author: {ex.Message}");
            }
        }

        public async Task<AuthorResponse> UpdateAuthorAsync(long id, Author author)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (existingAuthor == null)
                return new AuthorResponse("Author not found.");

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.Books = author.Books;

            try
            {
                _authorRepository.UpdateAuthor(existingAuthor);
                await _unitOfWork.CompleteAsync();

                return new AuthorResponse(existingAuthor);
            }
            catch (Exception ex)
            {
                return new AuthorResponse($"An error occurred when saving the author: {ex.Message}");
            }
        }

        public async Task<AuthorResponse> DeleteAuthorAsync(long id)
        {
            var existingAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (existingAuthor == null)
                return new AuthorResponse("Author not found.");

            try
            {
                _authorRepository.DeleteAuthor(existingAuthor);
                await _unitOfWork.CompleteAsync();

                return new AuthorResponse(existingAuthor);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AuthorResponse($"An error occurred when deleting the author: {ex.Message}");
            }
        }

        /*public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await FindAll()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
        }*/
    }
}
