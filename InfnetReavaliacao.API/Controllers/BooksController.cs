using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetReavaliacao.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // api/books?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var books = _bookService.GetAll(query);

            return Ok(books);
        }

        // api/books/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewBookInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _bookService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        // api/books/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _bookService.Update(inputModel);

            return NoContent();
        }

        // api/books/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
