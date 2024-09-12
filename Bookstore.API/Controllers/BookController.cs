using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<BookDTO> Get()
        {
            return this._bookService.GetBooks();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO book)
        {
            try
            {
                var created_book = await this._bookService.CreateBook(book);

                return Ok(created_book);
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
