using LibraryAPI.Domain.Repositories;
using LibraryAPI.Persistence.Contexts;
using LibraryAPI.Persistence.Repositories;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Persistence.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {

        public AuthorRepository(AppDbContext context) : base(context){ }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await FindAll().ToListAsync();
        }

        /*public async Task<Author> GetAuthorByIdAsync(long id)
        {
            return await _context.FindByCondition(a => a.Id == id).FirstOrDefaultAsync();
        }*/
    }
}
