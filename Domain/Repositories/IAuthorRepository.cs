using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> ListAsync();
        //Task<Author> GetAuthorByIdAsync(long id);
    }
}
