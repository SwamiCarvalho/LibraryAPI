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
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string genre = null, string author = null)
        {
            // Get all Books when there is no filter
            if (genre == null && author == null)
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
                // Split query route of author name
                if (!string.IsNullOrEmpty(author))
                {
                    

                    string[] firstLastName = Regex.Split(author, " ");
                    string firstName = firstLastName[0];
                    string lastName = null;
                    if (firstLastName.Length > 1)
                    {
                        
                        lastName = firstLastName[1];
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

            /*// Get all Books Filtered By Author
            else if (string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(author))
            {
                // Split query route of author name
                string[] firstLastName = Regex.Split(author, " ");
                string lastName = firstLastName[1];
                string firstName = firstLastName[0];

                var authorId = _context.Authors.Where(a => a.LastName.Equals(lastName) && a.FirstName.Equals(firstName))
                                              .Select(a => a.Id).AsQueryable().Single();

                var model = from b in _context.Books
                            from ba in _context.BooksAuthors
                            where ba.AuthorId == authorId
                            where b.Id == ba.BookId
                            select b;

                return await model.ToListAsync();
            }*/
            /*else if (!string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(author))
            {
                // Split query route of author name
                string[] firstLastName = Regex.Split(author, " ");
                string lastName = firstLastName[1];
                string firstName = firstLastName[0];

                // Get Genre Id by Name
                var genreId = _context.Genres.Where(g => g.Name.Equals(genre)).Select(g => g.Id).AsQueryable().Single();

                // Get Author Id by First and Last Name
                var authorId = _context.Authors.Where(a => a.FirstName.Equals(firstName) && a.LastName.Equals(lastName))
                                               .Select(a => a.Id).AsQueryable().Single();

                var model = from b in _context.Books
                            from ba in _context.BooksAuthors
                            where ba.AuthorId == authorId

                            from bg in _context.BooksGenres
                            where bg.GenreId == genreId
                            where b.Id == ba.BookId && b.Id == bg.BookId
                            select b;

                return await model.ToListAsync();
            }*/
        }
     


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookInGenre(long id)
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
