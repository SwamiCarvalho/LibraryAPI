using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Persistence.Repositories;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Repository
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {


        public GenreRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        /*public async Task<Genre> GetGenreByIdAsync(long? id)
        {
            return await FindByCondition(g => g.Id == id).FirstOrDefaultAsync();
        }*/
    }
}