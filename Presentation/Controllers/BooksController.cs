﻿using Entities.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IServiceManager _manager;

		public BooksController(IServiceManager manager)
		{
			_manager = manager;
		}

		[HttpGet("{id:int}")]
		public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
		{
			var book = _manager.BookService.GetOneBookById(id, false);
			return Ok(book);
		}

		[HttpGet]
		public IActionResult GetAllBooks()
		{
			var books = _manager.BookService.GetAllBooks(false);
			return Ok(books);
		}

		[HttpPost]
		public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
		{
			if (bookDto is null) { return BadRequest(); }

			var book = _manager.BookService.CreateOneBook(bookDto);
			return StatusCode(201, book);
		}

		[HttpPut("{id:int}")]
		public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
		{

			if (bookDto is null) { return BadRequest(); }
			_manager.BookService.UpdateOneBook(id, bookDto, true);
			return NoContent();
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
		{

			_manager.BookService.DeleteOneBook(id, false);
			return NoContent();
		}

		[HttpPatch("{id:int}")]
		public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDto> bookPatch)
		{
			var entity = _manager.BookService.GetOneBookById(id, false);

			bookPatch.ApplyTo(entity);
			_manager.BookService.UpdateOneBook(id,
				 new BookDtoForUpdate()
				 {
					 Id = entity.Id,
					 Title = entity.Title,
					 Price = entity.Price
				 },
				 true);
			return NoContent();
		}

	}
}
