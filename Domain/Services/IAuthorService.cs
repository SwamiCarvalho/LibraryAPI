using LibraryAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
        //Task<Author> GetAuthorByIdAsync(long id);
    }
}
