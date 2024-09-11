using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _bookstoreDbContext;

        public BookRepository(BookstoreDbContext bookstoreDbContext)
        {
            this._bookstoreDbContext = bookstoreDbContext;
        }

        public async Task<Book> Create(Book book)
        {
            if (book is not null)
            {
                await this._bookstoreDbContext.Books.AddAsync(book);
                await this._bookstoreDbContext.SaveChangesAsync();
            }

            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookstoreDbContext.Books.Include(x => x.Author);
        }

        public IEnumerable<Book> GetBooksByAuthor(int author_id)
        {
            return _bookstoreDbContext.Books.Where(x => x.Author.Id == author_id).ToList();
        }
    }
}
