using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Persistence.Contexts;

namespace LibraryAPI.Persistence.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {

        public GenreRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void AddGenre(Genre genre)
        {
            Create(genre);
        }
        public void UpdateGenre(Genre genre)
        {
            Update(genre);
        }
        public void DeleteGenre(Genre genre)
        {
            Delete(genre);
        }
        public async Task<Genre> GetGenreByIdAsync(long id)
        {
            return await FindByCondition(g => g.GenreId == id).FirstOrDefaultAsync();
        }
    }
}