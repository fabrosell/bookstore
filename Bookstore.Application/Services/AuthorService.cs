using Bookstore.Application.DTO;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }

        public async Task<AuthorDTO> CreateAuthor(AuthorDTO author)
        {
            var authorEntity = new Author()
            {
                RUT = author.RUT,
                DV = author.DV,
                FullName = author.FullName,
                BirthDate = author.BirthDate,
                City = author.City,
                eMail = author.eMail,
            };

            var created_author = await this._authorRepository.Create(authorEntity);

            return new AuthorDTO(created_author);
        }

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return this._authorRepository.GetAuthors()?.Select<Author, AuthorDTO>(x => new AuthorDTO(x));
        }
    }
}
