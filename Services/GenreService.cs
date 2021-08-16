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
    public class GenreService : IGenreService
    {

        public IGenreRepository _genreRepository;
        public readonly IUnitOfWork _unitOfWork;

        public GenreService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _genreRepository = repositoryWrapper.Genres;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await _genreRepository.ListAsync();
        }

        public async Task<GenreResponse> GetGenreByIdAsync(long id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);

            if (genre == null)
                return new GenreResponse("Genre not found.");

            return new GenreResponse(genre);
        }

        public async Task<GenreResponse> SaveGenreAsync(Genre genre)
        {
            try
            {
                _genreRepository.AddGenre(genre);
                await _unitOfWork.CompleteAsync();

                return new GenreResponse(genre);
            }
            catch (Exception ex)
            {
                return new GenreResponse($"An error occurred when saving the genre: {ex.Message}");
            }
        }

        public async Task<GenreResponse> UpdateGenreAsync(long id, Genre genre)
        {
            var existingGenre = await _genreRepository.GetGenreByIdAsync(id);

            if (existingGenre == null)
                return new GenreResponse("Genre not found.");

            existingGenre.Name = genre.Name;

            try
            {
                _genreRepository.UpdateGenre(existingGenre);
                await _unitOfWork.CompleteAsync();

                return new GenreResponse(existingGenre);
            }
            catch (Exception ex)
            {
                return new GenreResponse($"An error occurred when updating the genre: {ex.Message}");
            }
        }

        public async Task<GenreResponse> DeleteGenreAsync(long id)
        {
            var existingGenre = await _genreRepository.GetGenreByIdAsync(id);

            if (existingGenre == null)
                return new GenreResponse("Genre not found.");

            try
            {
                _genreRepository.DeleteGenre(existingGenre);
                await _unitOfWork.CompleteAsync();

                return new GenreResponse(existingGenre);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new GenreResponse($"An error occurred when deleting the genre: {ex.Message}");
            }
        }
    }
}