using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> ListAsync();
        //Task<Genre> GetGenreByIdAsync(long? id);
    }
}
