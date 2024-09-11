using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
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
        public async Task<BookDTO> Create(BookDTO book)
        {
            return await this._bookService.CreateBook(book);
        }
    }
}
