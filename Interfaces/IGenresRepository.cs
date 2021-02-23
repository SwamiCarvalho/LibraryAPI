using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IGenresRepository : IRepositoryBase<Genre>
    {
        Task<Genre> GetGenreByIdAsync(long? id);
    }
}
