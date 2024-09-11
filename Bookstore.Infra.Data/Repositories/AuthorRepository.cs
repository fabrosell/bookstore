using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _bookstoreDbContext;

        public AuthorRepository(BookstoreDbContext bookstoreDbContext)
        {
            this._bookstoreDbContext = bookstoreDbContext;
        }

        public async Task<Author> Create(Author author)
        {
            if (author is not null)
            {
                await this._bookstoreDbContext.AddAsync(author);
                await this._bookstoreDbContext.SaveChangesAsync();
            }

            return author;
        }

        public Author GetAuthor(int id)
        {
            return _bookstoreDbContext.Authors?.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _bookstoreDbContext.Authors.ToList();
        }

        public Author GetByRut(int rut)
        {
            return _bookstoreDbContext.Authors?.Where(x => x.RUT == rut).FirstOrDefault();
        }
    }
}
