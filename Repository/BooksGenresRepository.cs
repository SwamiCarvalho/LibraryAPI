using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class BooksGenresRepository : RepositoryBase<BooksGenres>, IBooksGenresRepository
    {


        public BooksGenresRepository(LibraryAPIDBContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<BooksGenres>> GetAllBooksGenresAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<IEnumerable<BooksGenres>> GetAllBooksWhereGenreId(long genreId)
        {
            return await FindByCondition(ba => ba.GenreId == genreId)
                .Include(b => b.Book)
                .ToListAsync();
        }
    }
}