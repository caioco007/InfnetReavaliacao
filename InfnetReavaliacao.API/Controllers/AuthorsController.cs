using InfnetReavaliacao.Application.InputModels;
using InfnetReavaliacao.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetReavaliacao.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // api/authors?query=net core
        [HttpGet]
        public ActionResult Get()
        {
            var authors = _authorService.GetAll();

            return Ok(authors);
        }

        // api/authors/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var author = _authorService.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NewAuthorInputModel inputModel)
        {
            if (inputModel.FullName.Length < 10)
            {
                return BadRequest();
            }

            var id = _authorService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        // api/authors/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UpdateAuthorInputModel inputModel)
        {
            if (inputModel.FullName.Length < 10)
            {
                return BadRequest();
            }

            _authorService.Update(inputModel);

            return NoContent();
        }

        // api/authors/3 DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _authorService.Delete(id);

            return NoContent();
        }
    }
}
