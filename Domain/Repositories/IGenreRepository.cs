using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> ListAsync();
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
        Task<Genre> GetGenreByIdAsync(long id);
    }
}
