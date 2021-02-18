using LibraryAPI.Models;
using LibraryAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IBooksGenresRepository : IRepositoryBase<BooksGenres>
    {
        Task<IEnumerable<BooksGenres>> GetAllBooksGenresAsync();

        Task<IEnumerable<BooksGenres>> GetAllBooksWhereGenreId(long genreId);
    }

}
