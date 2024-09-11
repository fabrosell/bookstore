using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public Author Author { get; set; }
        
        public bool IsValid()
        {
            return 
                !string.IsNullOrWhiteSpace(this.Name) &&
                IsValidISBN() &&
                Author != null &&
                Author.IsValid();
        }

        public string Error_Messages()
        {
            var errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.Name))
                errors.AppendLine("Debe incluir un título del libro");

            if (!IsValidISBN())
                errors.AppendLine("ISBN de libro inválido");

            if (this.Author is null || !this.Author.IsValid())
                errors.AppendLine(this.Author?.Error_Messages() ?? "Autor inválido");

            return errors.ToString();
        }


        private bool IsValidISBN()
        {
            // TODO: complete
            return true;
        }
    }
}
