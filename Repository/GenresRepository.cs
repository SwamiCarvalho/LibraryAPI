using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class GenresRepository : RepositoryBase<Genre>, IGenresRepository
    {


        public GenresRepository(LibraryAPIDBContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await FindAll()
                .OrderBy(b => b.Name)
                .ToListAsync();
        }
    }
}