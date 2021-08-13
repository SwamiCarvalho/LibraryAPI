using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;
using AutoMapper;
using LibraryAPI.Resources;
using Supermarket.API.Extensions;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorResource>> GetAllAsync()
        {
            var authors = await _authorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var author = _mapper.Map<SaveAuthorResource, Author>(resource);
            var result = await _authorService.SaveAuthorAsync(author);

            if (!result.Success)
                return BadRequest(result.Message);

            var authorResource = _mapper.Map<Author, AuthorResource>(author);
            return Ok(authorResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] SaveAuthorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var author = _mapper.Map<SaveAuthorResource, Author>(resource);
            var result = await _authorService.UpdateAuthorAsync(id, author);

            if (!result.Success)
                return BadRequest(result.Message);

            var authorResource = _mapper.Map<Author, AuthorResource>(result.Author);
            return Ok(authorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var authorResource = _mapper.Map<Author, AuthorResource>(result.Author);
            return Ok(authorResource);
        }

        // GET: api/Authors/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(long id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }*/

        /*// PUT: api/Authors/5
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
