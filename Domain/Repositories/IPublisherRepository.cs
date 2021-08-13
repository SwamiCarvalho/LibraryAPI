using System.Collections.Generic;
using LibraryAPI.Domain.Models;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> ListAsync();
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
        Task<Publisher> GetPublisherByIdAsync(long id);
    }
}
