using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public int Author_Id { get; set; }
        public string? Author_RUT { get; set; }
        public string? Author_FullName { get; set; }

        public BookDTO()
        {

        }

        public BookDTO(Book book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.Year = book.Year;
            this.Genre = book.Genre;
            this.Pages = book.Pages;
            this.ISBN = book.ISBN;
            this.Author_Id = book.Author.Id;
            // TODO: properly format rut number with thousand separator .
            this.Author_RUT = $"{book.Author.RUT}-{book.Author.DV}";
            this.Author_FullName = book.Author.FullName;
        }
    }
}
