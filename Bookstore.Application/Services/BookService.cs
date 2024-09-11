using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            this._authorRepository = authorRepository;
            this._bookRepository = bookRepository;
        }

        public async Task<BookDTO> CreateBook(BookDTO book)
        {
            var author = this._authorRepository.GetAuthor(book.Author_Id);

            // TODO: throw exception is author is not found

            var bookEntity = new Book()
            {
                Name = book.Name,
                Year = book.Year,
                Genre = book.Genre,
                Pages = book.Pages,
                ISBN = book.ISBN,
                Author = author,
            };

            var created_book = await this._bookRepository.Create(bookEntity);

            return new BookDTO(created_book);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            return this._bookRepository.GetBooks()?.Select<Book, BookDTO>(x => new BookDTO(x));
        }
    }
}
