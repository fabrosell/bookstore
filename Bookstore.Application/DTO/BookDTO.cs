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
        public int Author_RUT { get; set; }
        public char Autor_RUT_DV { get; set; }
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
            this.Author_RUT = book.Author.RUT;
            this.Autor_RUT_DV = book.Author.DV;
            this.Author_FullName = book.Author.FullName;
        }
    }
}
