using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> ListAsync();
        Task<AuthorResponse> GetAuthorByIdAsync(long id);
        Task<AuthorResponse> SaveAuthorAsync(Author author);
        Task<AuthorResponse> UpdateAuthorAsync(long id, Author author);
        Task<AuthorResponse> DeleteAuthorAsync(long id);
    }
}
