using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> ListAsync();
        //Task<Genre> GetGenreByIdAsync(long? id);
    }
}
