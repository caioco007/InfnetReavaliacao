using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetReavaliacao.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // api/authors?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var authors = _authorService.GetAll(query);

            return Ok(authors);
        }

        // api/authors/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewAuthorInputModel inputModel)
        {
            if (inputModel.FullName.Length > 50)
            {
                return BadRequest();
            }

            var id = _authorService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        // api/authors/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateAuthorInputModel inputModel)
        {
            if (inputModel.FullName.Length > 50)
            {
                return BadRequest();
            }

            _authorService.Update(inputModel);

            return NoContent();
        }

        // api/authors/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);

            return NoContent();
        }
    }
}
