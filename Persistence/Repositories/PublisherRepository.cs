using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using LibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories
{
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {

        public PublisherRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Publisher>> ListAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        /*public async Task<Author> GetPublisherByIdAsync(long id)
        {
            return await FindByCondition(a => a.Id == id).FirstOrDefaultAsync();
        }*/
    }
}
