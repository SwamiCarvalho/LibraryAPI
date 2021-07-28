using LibraryAPI.Data;
using LibraryAPI.Interfaces;
using System.Threading.Tasks;

namespace LibraryAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LibraryAPIDBContext _repoContext;

        private IBooksRepository _book;
        private IAuthorsRepository _author;
        private IGenresRepository _genre;
        private IBooksGenresRepository _bookgenre;
        private IBooksAuthorsRepository _bookauthor;


        public IBooksRepository Books {
            get
            {
                if(_book == null)
                {
                    _book = new BooksRepository(_repoContext);
                }
                return _book;
            }
        }

        public IAuthorsRepository Authors
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorsRepository(_repoContext);
                }
                return _author;
            }
        }


        public IGenresRepository Genres
        {
            get
            {
                if (_genre == null)
                {
                    _genre = new GenresRepository(_repoContext);
                }
                return _genre;
            }
        }

        public IBooksGenresRepository BooksGenres
        {
            get
            {
                if (_bookgenre == null)
                {
                    _bookgenre = new BooksGenresRepository(_repoContext);
                }
                return _bookgenre;
            }
        }


        public IBooksAuthorsRepository BooksAuthors
        {
            get
            {
                if (_bookauthor == null)
                {
                    _bookauthor = new BooksAuthorsRepository(_repoContext);
                }
                return _bookauthor;
            }
        }


        public RepositoryWrapper(LibraryAPIDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
