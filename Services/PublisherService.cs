using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services.Communication;
using System;

namespace LibraryAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public readonly IUnitOfWork _unitOfWork;
        public PublisherService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _publisherRepository = repositoryWrapper.Publishers;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await _publisherRepository.ListAsync();
        }

        public async Task<PublisherResponse> SavePublisherAsync(Publisher publisher)
        {
            try
            {
                _publisherRepository.AddPublisher(publisher);
                await _unitOfWork.CompleteAsync();

                return new PublisherResponse(publisher);
            }
            catch (Exception ex)
            {
                return new PublisherResponse($"An error occurred when saving the publisher: {ex.Message}");
            }
        }

        public async Task<PublisherResponse> UpdatePublisherAsync(long id, Publisher publisher)
        {
            var existingPublisher = await _publisherRepository.GetPublisherByIdAsync(id);

            if (existingPublisher == null)
                return new PublisherResponse("Publisher not found.");

            existingPublisher.Name = publisher.Name;
            existingPublisher.Location = publisher.Location;
            existingPublisher.Books = publisher.Books;

            try
            {
                _publisherRepository.UpdatePublisher(existingPublisher);
                await _unitOfWork.CompleteAsync();

                return new PublisherResponse(existingPublisher);
            }
            catch (Exception ex)
            {
                return new PublisherResponse($"An error occurred when updating the publisher: {ex.Message}");
            }
        }

        public async Task<PublisherResponse> DeletePublisherAsync(int id)
        {
            var existingPublisher = await _publisherRepository.GetPublisherByIdAsync(id);

            if (existingPublisher == null)
                return new PublisherResponse("Publisher not found.");

            try
            {
                _publisherRepository.DeletePublisher(existingPublisher);
                await _unitOfWork.CompleteAsync();

                return new PublisherResponse(existingPublisher);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PublisherResponse($"An error occurred when deleting the publisher: {ex.Message}");
            }
        }

        public async Task<PublisherResponse> GetPublisherByIdAsync(long id)
        {
            var publisher = await _publisherRepository.GetPublisherByIdAsync(id);

            if (publisher == null)
                return new PublisherResponse("Publisher not found.");

            return new PublisherResponse(publisher);
        }

        /*public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(b => b.Title);
        }

        public IEnumerable<Book> GetAllBooksWithDetails()
        {
            return FindAll()
                .Include(b => b.BooksPublishers)
                    .ThenInclude(bg => bg.Publisher)
                .Include(b => b.BooksPublishers)
                    .ThenInclude(ba => ba.Publisher)
                .OrderBy(b => b.Title).ToList();
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            return await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookDetailsAsync(long? id)
        {
            return await FindByCondition(b => b.Id == id).AsQueryable()
                .Include(b => b.BooksPublishers)
                    .ThenInclude(bg => bg.Publisher)
                .Include(b => b.BooksPublishers)
                    .ThenInclude(ba => ba.Publisher)
                .OrderBy(b => b.Title).FirstOrDefaultAsync();

        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }*/

    }
}
