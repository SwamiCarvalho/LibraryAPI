using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> ListAsync();
        //Task<Genre> GetGenreByIdAsync(long? id);
    }
}
