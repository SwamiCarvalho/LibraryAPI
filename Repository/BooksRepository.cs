using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class BooksRepository : RepositoryBase<Book>, IBooksRepository
    {


        public BooksRepository(LibraryAPIDBContext repositoryContext)
            :base(repositoryContext)
        {
        }


        public IQueryable<Book> GetAllBooks()
        {
            return FindAll()
                /*.Include(b => b.BooksGenres)
                    .ThenInclude(bg => bg.Genre)
                .Include(b => b.BooksAuthors)
                    .ThenInclude(ba => ba.Author)*/
                .OrderBy(b => b.Title);
        }

        public async Task<Book> GetBookByIdAsync(long id)
        {
            return await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();
        }

        public bool BookExists(long id)
        {
            return FindAll().Any(b => b.Id == id);
        }

    }
}
