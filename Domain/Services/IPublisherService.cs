using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> ListAsync();
        Task<PublisherResponse> SavePublisherAsync(Publisher publisher);
        Task<PublisherResponse> UpdatePublisherAsync(long id, Publisher publisher);
        Task<PublisherResponse> DeletePublisherAsync(int id);
        Task<PublisherResponse> GetPublisherByIdAsync(long id);
    }
}
