using LibraryAPI.Models;
using LibraryAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Interfaces
{
    public interface IAuthorsRepository : IRepositoryBase<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
    }
}
