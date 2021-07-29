using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;
using LibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {


        public readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorRepository.ListAsync();
        }


        /*public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await FindAll()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(long id)
        {
            return await FindByCondition(a => a.Id == id).FirstOrDefaultAsync();
        }*/
    }
}
