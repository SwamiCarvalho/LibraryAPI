using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await _authorService.ListAsync();
            return authors;
        }

        /*// GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _authorService.Authors.FindAll().ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(long id)
        {
            var author = await _authorService.Authors.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(long id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var authorEntity = await _authorService.Authors.GetAuthorByIdAsync(id);

            try
            {
                await _authorService.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (authorEntity == null)
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _authorService.Authors.Create(author);
            await _authorService.SaveAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(long id)
        {
            var author = await _authorService.Authors.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _authorService.Authors.Delete(author);
            await _authorService.SaveAsync();

            return NoContent();
        }

        private bool AuthorExists(long id)
        {
            return _authorService.Authors.FindAll().Any(e => e.Id == id);
        }*/
    }
}
