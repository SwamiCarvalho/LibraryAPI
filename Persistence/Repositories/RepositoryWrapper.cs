using LibraryAPI.Domain.Repositories;
using LibraryAPI.Domain.Services;
using LibraryAPI.Persistence.Contexts;
using LibraryAPI.Persistence.Repositories;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _repoContext;

        private IBookRepository _book;
        private IAuthorRepository _author;
        private IGenreRepository _genre;
        private IPublisherRepository _publisher;


        public IBookRepository Books
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_repoContext);
                }
                return _book;
            }
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_repoContext);
                }
                return _author;
            }
        }


        public IGenreRepository Genres
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenreRepository(_repoContext);
                }
                return _genre;
            }
        }

        public IPublisherRepository Publishers
        {
            get
            {
                if (_publisher == null)
                {
                    _publisher = new PublisherRepository(_repoContext);
                }
                return _publisher;
            }
        }

        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
