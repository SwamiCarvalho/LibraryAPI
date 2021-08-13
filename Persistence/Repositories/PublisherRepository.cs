using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {

        public PublisherRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void AddPublisher(Publisher publisher)
        {
            Create(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            Update(publisher);
        }
        public void DeletePublisher(Publisher publisher)
        {
            Delete(publisher);
        }

        public async Task<Publisher> GetPublisherByIdAsync(long id)
        {
            return await FindByCondition(a => a.PublisherId == id).FirstOrDefaultAsync();
        }
    }
}
