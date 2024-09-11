using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public int RUT { get; set; }
        public char DV { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string eMail { get; set; }

        public AuthorDTO()
        {

        }

        public AuthorDTO(Author author)
        {
            this.Id = author.Id;
            this.RUT = author.RUT;
            this.DV = author.DV;
            this.FullName = author.FullName;
            this.BirthDate = author.BirthDate;
            this.City = author.City;
            this.eMail = author.eMail;
        }
    }
}
