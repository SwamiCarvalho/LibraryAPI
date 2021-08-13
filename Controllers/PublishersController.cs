using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Domain.Models;
using LibraryAPI.Domain.Services;
using AutoMapper;
using Supermarket.API.Extensions;
using LibraryAPI.Resources;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;
        private IMapper _mapper;
        //private readonly ILogger<PublishersController> _logger;

        public PublishersController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            var publishers = await _publisherService.ListAsync();
            return publishers;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PublisherResource savePublisherResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publisher = _mapper.Map<PublisherResource, Publisher>(savePublisherResource);
            var result = await _publisherService.SavePublisherAsync(publisher);

            if (!result.Success)
                return BadRequest(result.Message);

            var publisherResource = _mapper.Map<Publisher, PublisherResource>(publisher);
            return Ok(publisherResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] PublisherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publisher = _mapper.Map<PublisherResource, Publisher>(resource);
            var result = await _publisherService.UpdatePublisherAsync(id, publisher);

            if (!result.Success)
                return BadRequest(result.Message);

            var publisherResource = _mapper.Map<Publisher, PublisherResource>(result.Publisher);
            return Ok(publisherResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publisherService.DeletePublisherAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var publisherResource = _mapper.Map<Publisher, PublisherResource>(result.Publisher);
            return Ok(publisherResource);
        }

        /*// GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(long id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutPublisher(long id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisher", new { id = publisher.Id, name = publisher.Name, location = publisher.Location }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(long id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherExists(long id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }*/
    }
}
