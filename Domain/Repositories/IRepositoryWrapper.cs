using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        IGenreRepository Genres { get; }
        IPublisherRepository Publishers { get; }
        Task SaveAsync();
    }
}
