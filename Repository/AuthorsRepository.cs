using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class AuthorsRepository : RepositoryBase<Author>, IAuthorsRepository
    {


        public AuthorsRepository(LibraryAPIDBContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await FindAll()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
        }
    }
}
