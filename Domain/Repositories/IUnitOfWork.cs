using System.Threading.Tasks;

namespace LibraryAPI.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}