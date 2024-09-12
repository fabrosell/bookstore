using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<AuthorDTO> Get()
        {
            return this._authorService.GetAuthors();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDTO author)
        {
            try
            {
                var created_author = await this._authorService.CreateAuthor(author);

                return Ok(created_author);
            }
            catch (Exception ex)
            {
                if (ex is BookstoreException)
                    return BadRequest(ex.Message);

                return StatusCode(500);
            }
        }
    }
}
