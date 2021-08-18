using LibraryAPI.Domain.Repositories;
using LibraryAPI.Persistence.Contexts;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public void AddAuthor(Author author)
        {
            Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            Update(author);
        }
        
        public void DeleteAuthor(Author author)
        {
            Delete(author);
        }

        public async Task<Author> GetAuthorByIdAsync(long id)
        {
            return await FindByCondition(a => a.AuthorId == id).FirstOrDefaultAsync();
        }
    }
}
