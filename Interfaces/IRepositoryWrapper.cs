using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBooksRepository Books { get; }
        IAuthorsRepository Authors { get; }
        IGenresRepository Genres { get; }
        IBooksGenresRepository BooksGenres { get; }
        IBooksAuthorsRepository BooksAuthors { get; }
        Task SaveAsync();
    }
}
