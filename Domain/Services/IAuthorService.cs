using LibraryAPI.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
        Task<AuthorResponse> SaveAuthorAsync(Author author);
        Task<AuthorResponse> UpdateAuthorAsync(long id, Author author);
        Task<AuthorResponse> DeleteAuthorAsync(int id);
        Task<AuthorResponse> GetAuthorByIdAsync(long id);
    }
}
