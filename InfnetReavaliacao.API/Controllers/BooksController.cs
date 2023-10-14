using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetReavaliacao.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // api/books?query=net core
        [HttpGet]
        public ActionResult Get()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        // api/books/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NewBookInputModel inputModel)
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
        public ActionResult Put(int id, [FromBody] UpdateBookInputModel inputModel)
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
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
