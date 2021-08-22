using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;
using AutoMapper;
using LibraryAPI.Resources;
using Supermarket.API.Extensions;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        //private readonly ILogger<BooksController> _logger;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreResource>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            var resources = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
            return Ok(resources);
        }

        // GET: api/genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreResource>> GetGenre(long id)
        {
            var result = await _genreService.GetGenreByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var genreResource = _mapper.Map<Genre, GenreResource>(result.Genre);
            return Ok(genreResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(SaveGenreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var genre = _mapper.Map<SaveGenreResource, Genre>(resource);
            var result = await _genreService.SaveGenreAsync(genre);

            if (!result.Success)
                return BadRequest(result.Message);

            var genreResource = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(genreResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, GenreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var genre = _mapper.Map<GenreResource, Genre>(resource);
            var result = await _genreService.UpdateGenreAsync(id, genre);

            if (!result.Success)
                return BadRequest(result.Message);

            var genreResource = _mapper.Map<Genre, GenreResource>(result.Genre);
            return Ok(genreResource);
        }

        // DELETE: api/genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            var result = await _genreService.DeleteGenreAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var genreResource = _mapper.Map<Genre, GenreResource>(result.Genre);
            return Ok(genreResource);
        }

        // GET: api/genres/5
        /*[HttpGet("{genreName}")]
        public async Task<ActionResult<GenreResource>> GetGenreAllBooks(long id)
        {
            var result = await _genreService.GetGenreBooks(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var booksResource = _mapper.Map<IList<Book>, IList<BookResource>>(result.Books);
            return Ok(booksResource);
        }*/

        /*// GET: api/Genres
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            var genre = _genreService.FindAll().OrderBy(g => g.Name).ToList();
            return Ok(genre);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _repo.Genres.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            //var genre = _mapper.Map<GenreDTO>(genreEntity);
            return Ok(genre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Genre> PutGenre([Bind("Id,Name")] Genre genre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _repo.Genres.Update(genre);
  
                _repo.SaveAsync();
                return Ok(genre);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _repo.Genres.Create(genre);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute]long id)
        {
            var genre = await _repo.Genres.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _repo.Genres.Delete(genre);
            await _repo.SaveAsync();

            return Ok();
        }

        private bool GenreExists(long id)
        {
            return _repo.Genres.FindAll().Any(e => e.Id == id);
        }*/
    }
}
