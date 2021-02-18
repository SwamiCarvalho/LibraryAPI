using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.DTOs;
using System.Text.RegularExpressions;
using AutoMapper;
using LibraryAPI.Interfaces;
using Microsoft.Extensions.Logging;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private IRepositoryWrapper _repo;
        private IMapper _mapper;
        //private readonly ILogger<BooksController> _logger;

        public BooksController(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetBooks( [FromQuery] string searchTerm = null, [FromQuery] string genre = null, [FromQuery] string author = null)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var books = await _repo.Books.FindByCondition(b => searchTerm == null || b.Title.Contains(searchTerm) || b.OgTitle.Contains(searchTerm)).ToListAsync();

                var booksResult = _mapper.Map<IEnumerable<BookDTO>>(books);
                return booksResult;
            }
            // Get all Books when there is no filter
            else if (searchTerm == null && genre == null && author == null)
            {
                var books = _repo.Books.GetAllBooks();
                var model = _mapper.Map<IEnumerable<BookDTO>>(books);
                return model;
            }
            // Get all Books Filtered By Genre
            else
            {
            
                long? authorId = null;
                // If parameter Author Name is passed
                if (!string.IsNullOrEmpty(author))
                {
                    // Split Author Name Parameter
                    string[] firstLastName = Regex.Split(author, " ");

                    // Get First Name from parameter
                    string firstName;
                    string lastName;
                    // Condition, if Parameter has two names, get last name else set to null
                    if (firstLastName.Length > 1)
                    {
                        lastName = firstLastName[0];
                        firstName = firstLastName[1];
                    } 
                    else
                    {
                        firstName = firstLastName[0];
                        lastName = null; 
                    }

                    // Get Author Id by Name
                    authorId = _repo.Authors
                        .FindByCondition(a => a.LastName.Equals(lastName) && a.FirstName.Equals(firstName) || author == null)
                        .Select(a => a.Id).AsQueryable().Single();

                }

                long? genreId = null;
                if (!string.IsNullOrEmpty(genre))
                {
                    // Get Genre Id by Name
                    genreId = _repo.Genres
                        .FindByCondition(g => g.Name.Equals(genre) || genre == null)
                        .Select(g => g.Id).AsQueryable().Single();

                                             
                }

                // Get All Books Where Conditions are satisfied
                var modelQuery = from b in _repo.Books.GetAllBooks()
                            from bg in _repo.BooksGenres.FindAll()
                            where bg.GenreId == genreId || genreId == null

                            from ba in _repo.BooksAuthors.FindAll()
                            where ba.AuthorId == authorId || authorId == null
                            where b.Id == bg.BookId && b.Id == ba.BookId
                            select b;

                modelQuery = modelQuery.AsQueryable().Distinct()
                    .Include(b => b.BooksGenres)
                        .ThenInclude(bg => bg.Genre)
                    .Include(b => b.BooksAuthors)
                        .ThenInclude(ba => ba.Author);

                var model = _mapper.Map<IEnumerable<BookDTO>>(modelQuery);
                return model;
            }
        }


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookbyId(long id )
        {
            var book = await _repo.Books.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, [FromBody]Book book)
        {
            try
            {
                if (book == null)
                {
                    //_logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid book object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var bookEntity = await _repo.Books.GetBookByIdAsync(id);
                if (bookEntity == null)
                {
                    //_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(book, bookEntity);
                _repo.Books.Update(bookEntity);
                await _repo.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _repo.Books.Create(book);
            await _repo.SaveAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _repo.Books.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _repo.Books.Delete(book);
            await _repo.SaveAsync();

            return NoContent();
        }

    }


}
