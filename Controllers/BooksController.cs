using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Domain.Services;
using LibraryAPI.Resources;
using Supermarket.API.Extensions;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        //private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        //[ResponseType(typeof(BookResource))]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAllBooks()
        {
            var result = await _bookService.GetAllBooksAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsResource>> GetBookById(long id)
        {
            var result = await _bookService.GetBookByIdAsync(id, true);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.BookDetails);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveBookResource newBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var result = await _bookService.SaveBookAsync(newBook);

            //db.Entry(book).Reference(x => x.Author).Load();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody]BookDetailsResource bookDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _bookService.UpdateBookAsync(id, bookDetails);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Book);
        }

        /*// GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetBooks([FromQuery] string searchTerm, [FromQuery] string book, [FromQuery] string book)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var modelR = await _bookService.Books.FindByCondition(b => searchTerm == null || b.Title.Contains(searchTerm) || b.OgTitle.Contains(searchTerm)).AsQueryable()
                        .Include(b => b.BooksBooks)
                            .ThenInclude(bg => bg.Book)
                        .Include(b => b.BooksBooks)
                            .ThenInclude(ba => ba.Book)
                        .ToListAsync();

                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
                }
                // Get all Books when there is no filter
                else if (searchTerm == null && book == null && book == null)
                {
                    var modelR = _bookService.Books.GetAllBooksWithDetails();
                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
                }
                // Get all Books Filtered By Book
                else
                {

                    long? bookId = null;
                    // If parameter Book Name is passed
                    if (!string.IsNullOrEmpty(book))
                    {
                        // Split Book Name Parameter
                        string[] firstLastName = Regex.Split(book, " ");

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

                        // Get Book Id by Name
                        bookId = _bookService.Books
                            .FindByCondition(a => a.LastName.Equals(lastName) && a.FirstName.Equals(firstName) || book == null)
                            .Select(a => a.Id).AsQueryable().Single();

                    }

                    long? bookId = null;
                    if (!string.IsNullOrEmpty(book))
                    {
                        // Get Book Id by Name
                        bookId = _bookService.Books
                            .FindByCondition(g => g.Name.Equals(book) || book == null)
                            .Select(g => g.Id).AsQueryable().Single();


                    }

                    // Get All Books Where Conditions are satisfied
                    var modelQuery = from b in _bookService.Books.GetAllBooksWithDetails()
                                     from bg in _bookService.BooksBooks.FindAll()
                                     where bg.BookId == bookId || bookId == null

                                     from ba in _bookService.BooksBooks.FindAll()
                                     where ba.BookId == bookId || bookId == null
                                     where b.Id == bg.BookId && b.Id == ba.BookId
                                     select b;

                    var modelR = modelQuery.AsQueryable().Distinct()
                                    *//*.Include(b => b.BooksBooks)
                                        .ThenInclude(bg => bg.Book)
                                    .Include(b => b.BooksBooks)
                                        .ThenInclude(ba => ba.Book)*//*.ToList();

                    var model = _mapper.Map<List<BookDTO>>(modelR);
                    return Ok(model);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        */


    }
}
