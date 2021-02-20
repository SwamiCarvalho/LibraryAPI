﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Interfaces;
using LibraryAPI.Models.DTOs;
using AutoMapper;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private IMapper _mapper;

        public GenresController(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> GetGenres()
        {
            var genreEntity = await _repo.Genres.GetAllGenresAsync();
            var genre = _mapper.Map<List<GenreDTO>>(genreEntity);
            return genre;
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre([FromRoute]long id)
        {
            var genre = await _repo.Genres.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            //var genre = _mapper.Map<Genre>(genreEntity);
            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(long id, Genre genre)
        {
            try
            {
                if (genre == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var genreEntity = await _repo.Genres.GetGenreByIdAsync(id);
                if (genreEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(genre, genreEntity);
                _repo.Genres.Update(genreEntity);
                await _repo.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre([FromBody]Genre genre)
        {
            _repo.Genres.Create(genre);
            await _repo.SaveAsync();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            var genre = await _repo.Genres.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _repo.Genres.Delete(genre);
            await _repo.SaveAsync();

            return NoContent();
        }

        private bool GenreExists(long id)
        {
            return _repo.Genres.FindAll().Any(e => e.Id == id);
        }
    }
}
