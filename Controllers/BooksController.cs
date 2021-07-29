using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Domain.Models;
using System.Text.RegularExpressions;
using LibraryAPI.Domain.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LibraryAPI.Domain.Models.DTOs;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private IMapper _mapper;
        //private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var categories = await _bookService.ListAsync();
            return categories;
        }

        /*// GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks([FromQuery] string searchTerm, [FromQuery] string genre, [FromQuery] string author)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var modelR = await _bookService.Books.FindByCondition(b => searchTerm == null || b.Title.Contains(searchTerm) || b.OgTitle.Contains(searchTerm)).AsQueryable()
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
                    var modelR = _bookService.Books.GetAllBooksWithDetails();
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
                        authorId = _bookService.Authors
                            .FindByCondition(a => a.LastName.Equals(lastName) && a.FirstName.Equals(firstName) || author == null)
                            .Select(a => a.Id).AsQueryable().Single();

                    }

                    long? genreId = null;
                    if (!string.IsNullOrEmpty(genre))
                    {
                        // Get Genre Id by Name
                        genreId = _bookService.Genres
                            .FindByCondition(g => g.Name.Equals(genre) || genre == null)
                            .Select(g => g.Id).AsQueryable().Single();


                    }

                    // Get All Books Where Conditions are satisfied
                    var modelQuery = from b in _bookService.Books.GetAllBooksWithDetails()
                                     from bg in _bookService.BooksGenres.FindAll()
                                     where bg.GenreId == genreId || genreId == null

                                     from ba in _bookService.BooksAuthors.FindAll()
                                     where ba.AuthorId == authorId || authorId == null
                                     where b.Id == bg.BookId && b.Id == ba.BookId
                                     select b;

                    var modelR = modelQuery.AsQueryable().Distinct()
                                    *//*.Include(b => b.BooksGenres)
                                        .ThenInclude(bg => bg.Genre)
                                    .Include(b => b.BooksAuthors)
                                        .ThenInclude(ba => ba.Author)*//*.ToList();

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
        public async Task<ActionResult<BookDetailsDTO>> GetBookById(long? id)
        {
            try
            {
                BookDetailsDTO book = new BookDetailsDTO();

                if(id == null)
                {
                    NotFound();
                }

                var bookEntity = await _bookService.Books.GetBookDetailsAsync(id);

                if (bookEntity == null)
                {
                    return NotFound();
                }
                book = _mapper.Map<BookDetailsDTO>(bookEntity);
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
        public ActionResult<Book> UpdateBook([Bind("Id,Title,OgTitle,PublicationYear,Edition,Notes,PhysicalDescription")] Book book)
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

                _bookService.Books.Update(book);
                _bookService.SaveAsync();

                return Ok(book);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            _bookService.Books.Create(book);
            _bookService.SaveAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }


        // DELETE: api/Books/5
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(long id)
        {
            try
            {
                var book = await _bookService.Books.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                //_bookService.Books.Delete(book);
                //await _bookService.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }*/


        /*// DELETE: api/Books/5
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute]long id)
        {
            try
            {
                var book = await _bookService.Books.GetBookByIdAsync(id);

                if (book == null)
                {
                    return NotFound();
                }
                _bookService.Books.Delete(book);
                await _bookService.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }*/
    }
}
