
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contract;
using Repositories.EfCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager.Book.GetOneBookById(id, false);
                return book is null
                    ? NotFound()
                    : Ok(book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.Book.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null) { return BadRequest(); }

                _manager.Book.CreateOneBooks(book);
                _manager.Save();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                var entity = _manager.Book.GetOneBookById(id, true);

                if (entity is null) { return NotFound(); }
                if (id != book.Id) { return BadRequest(); }

                entity.Title = book.Title;
                entity.Price = book.Price;

                _manager.Book.UpdateOneBooks(entity);
                _manager.Save();
                return Ok(book);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _manager.Book.GetOneBookById(id, true);

                if (entity is null) 
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message=$"Book with id:{id} could not found."
                    }) ;
                }
                _manager.Book.DeleteOneBook(entity);
                _manager.Save();
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateeOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument bookPatch)
        {

            try
            {
                var entity = _manager.Book.GetOneBookById(id, true);

                if (entity is null) { return NotFound(); }

                bookPatch.ApplyTo(entity);
                _manager.Book.UpdateOneBooks(entity);
                return NoContent();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

      }
}
