using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class GenreService : IGenreService
    {

        public readonly IGenreRepository _genreRepository;

        public GenreService(IRepositoryWrapper repositoryWrapper)
        {
            this._genreRepository = repositoryWrapper.Genres;
        }
        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await _genreRepository.ListAsync();
        }


        /*public async Task<Genre> GetGenreByIdAsync(long? id)
        {
            return await FindByCondition(g => g.Id == id).FirstOrDefaultAsync();
        }*/
    }
}