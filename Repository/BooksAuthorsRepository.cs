using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class BooksAuthorsRepository : RepositoryBase<BooksAuthors>, IBooksAuthorsRepository
    {


        public BooksAuthorsRepository(LibraryAPIDBContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<BooksAuthors>> GetAllBooksAuthorsAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<IEnumerable<BooksAuthors>> GetAllBooksWhereAuthorId(long authorId)
        {
            return await FindByCondition(ba => ba.AuthorId == authorId)
                .Include(b => b.Book)
                .ToListAsync();
        }
    }
}
