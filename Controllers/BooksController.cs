using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using System.Linq.Expressions;
using LibraryAPI.DTOs;
using System.Text.RegularExpressions;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryAPIDBContext _context;

        public BooksController(LibraryAPIDBContext context)
        {
            _context = context;
        }


        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string searchTerm = null, string genre = null, string author = null)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var model = await _context.Books
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .Where(b => searchTerm == null || b.Title.Contains(searchTerm) || b.OgTitle.Contains(searchTerm))

                .ToListAsync();
                return model;
            }
            // Get all Books when there is no filter
            else if (genre == null && author == null)
            {
                var model = await _context.Books
                                    .AsNoTracking()
                                    .OrderBy(b => b.Title)
                                    .ToListAsync();

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

                    authorId = _context.Authors.Where(a => a.LastName.Equals(lastName) 
                                                    && a.FirstName.Equals(firstName) 
                                                    || author == null)
                                               .Select(a => a.Id).AsQueryable().Single();
                }

                long? genreId = null;
                if (!string.IsNullOrEmpty(genre))
                {
                    // Get Genre Id by Name
                    genreId = _context.Genres.Where(g => g.Name.Equals(genre) 
                                                || genre == null)
                                             .Select(g => g.Id).AsQueryable().Single();
                }


                // Get All Books Where Conditions are satisfied
                var model = from b in _context.Books
                                from bg in _context.BooksGenres
                                where bg.GenreId == genreId || genreId == null

                                from ba in _context.BooksAuthors
                                where ba.AuthorId == authorId || authorId == null
                            where b.Id == bg.BookId && b.Id == ba.BookId
                            select b;

                return await model.Distinct().ToListAsync();
            }
        }


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookbyId(long id )
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
