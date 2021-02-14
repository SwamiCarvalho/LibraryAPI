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
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                var model = await _context.Books
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();
                return model;
            }
            else
            {
                var genreId = _context.Genres.Where(g => g.Name.Equals(genre)).Select(g => g.Id).AsQueryable().Single();

                var model = from b in _context.Books
                            from bg in _context.BooksGenres
                            where bg.GenreId == genreId
                            where b.Id == bg.BookId
                            select b;

                return await model.ToListAsync();
            }
            
         }


        // GET: api/Books/genre - Get Books by Genre
        //[HttpGet("{genre}")]
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(string genre)
        {
            
        }*/

        // GET: api/Books/5
        //[HttpGet("{id}")]
        /*public async Task<ActionResult<Book>> GetBook(long id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }*/

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
