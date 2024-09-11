using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<AuthorDTO> Create(AuthorDTO author)
        {
            return await this._authorService.CreateAuthor(author);
        }
    }
}
