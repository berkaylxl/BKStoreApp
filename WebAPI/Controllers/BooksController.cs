using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")] int id)
        {
            var book  = _context.Books
                .Where(x => x.Id == id)
                .SingleOrDefault();

             return book == null ? NotFound() : Ok(book);

        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
           if(book is null) { return BadRequest(); }
            _context.Books.Add(book);
            _context.SaveChanges();
            return StatusCode(201, book);
        }
    }
}
