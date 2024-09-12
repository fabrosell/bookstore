using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Bookstore.Domain;
using Bookstore.Domain.Exceptions;
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
        private readonly IBookstoreConfiguration _bookstoreConfiguration;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(
            IBookstoreConfiguration bookstoreConfiguration,
            IAuthorRepository authorRepository, 
            IBookRepository bookRepository)
        {
            this._bookstoreConfiguration = bookstoreConfiguration;
            this._authorRepository = authorRepository;
            this._bookRepository = bookRepository;
        }

        public async Task<BookDTO> CreateBook(BookDTO book)
        {
            var author = this._authorRepository.GetByRut(book.Author_RUT);

            if (author is null)
                throw new AuthorNotFoundException("El autor no está registrado");

            var author_books = this._bookRepository.GetBooksByAuthor(author.Id);
            
            if (author_books is not null && author_books.Count() >= this._bookstoreConfiguration.Get_Max_Books_Per_Author())
                throw new MaxBooksPerAuthorException($"No es posible registrar el libro, se alcanzó el máximo permitido (max: {this._bookstoreConfiguration.Get_Max_Books_Per_Author()})");            

            var bookEntity = new Book()
            {
                Name = book.Name,
                Year = book.Year,
                Genre = book.Genre,
                Pages = book.Pages,
                ISBN = book.ISBN,
                Author = author,
            };

            if (!bookEntity.IsValid())
                throw new InvalidAuthorException(bookEntity.Error_Messages());

            var created_book = await this._bookRepository.Create(bookEntity);

            return new BookDTO(created_book);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            return this._bookRepository.GetBooks()?.Select<Book, BookDTO>(x => new BookDTO(x));
        }
    }
}
