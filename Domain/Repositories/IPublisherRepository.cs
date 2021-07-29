using System.Collections.Generic;
using LibraryAPI.Domain.Models;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> ListAsync();
        //Task<Genre> GetPublisherByIdAsync(long? id);
    }
}
