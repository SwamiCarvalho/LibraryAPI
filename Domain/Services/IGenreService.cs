using LibraryAPI.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> ListAsync();
        Task<GenreResponse> GetGenreByIdAsync(long id);
        Task<GenreResponse> SaveGenreAsync(Genre genre);
        Task<GenreResponse> UpdateGenreAsync(long id, Genre genre);
        Task<GenreResponse> DeleteGenreAsync(long id);
    }
}
