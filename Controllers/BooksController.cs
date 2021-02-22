using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using System.Text.RegularExpressions;
using LibraryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LibraryAPI.Models.DTOs;

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
        public async Task<ActionResult<List<BookDTO>>> GetBooks([FromQuery] string searchTerm, [FromQuery] string genre, [FromQuery] string author)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var modelR = await _repo.Books.FindByCondition(b => searchTerm == null || b.Title.Contains(searchTerm) || b.OgTitle.Contains(searchTerm)).AsQueryable()
                        .Include(b => b.BooksGenres)
                            .ThenInclude(bg => bg.Genre)
                        .Include(b => b.BooksAuthors)
                            .ThenInclude(ba => ba.Author)
                        .ToListAsync();

                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
                }
                // Get all Books when there is no filter
                else if (searchTerm == null && genre == null && author == null)
                {
                    var modelR = _repo.Books.GetAllBooksWithDetails();
                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
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
                    var modelQuery = from b in _repo.Books.GetAllBooksWithDetails()
                                     from bg in _repo.BooksGenres.FindAll()
                                     where bg.GenreId == genreId || genreId == null

                                     from ba in _repo.BooksAuthors.FindAll()
                                     where ba.AuthorId == authorId || authorId == null
                                     where b.Id == bg.BookId && b.Id == ba.BookId
                                     select b;

                    var modelR = modelQuery.AsQueryable().Distinct()
                                    /*.Include(b => b.BooksGenres)
                                        .ThenInclude(bg => bg.Genre)
                                    .Include(b => b.BooksAuthors)
                                        .ThenInclude(ba => ba.Author)*/.ToList();

                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookbyId(long id)
        {
            try
            {
                var bookEntity = await _repo.Books.GetBookDetailsAsync(id);

                if (bookEntity == null)
                {
                    return NotFound();
                }
                var book = _mapper.Map<BookDetailsDTO>(bookEntity);
                return Ok(book);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }



        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(long id, Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var bookEntity = await _repo.Books.GetBookByIdAsync(id);
                if (bookEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(book, bookEntity);
                _repo.Books.Update(bookEntity);
                await _repo.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _repo.Books.Create(book);
            await _repo.SaveAsync();

            return CreatedAtAction("BookbyId", new { id = book.Id }, book);
        }


        // DELETE: api/Books/5
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(long id)
        {
            try
            {
                var book = await _repo.Books.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                //_repo.Books.Delete(book);
                //await _repo.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        /*// DELETE: api/Books/5
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute]long id)
        {
            try
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
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }*/
    }
}
