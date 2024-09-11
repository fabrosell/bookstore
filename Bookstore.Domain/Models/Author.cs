using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public int RUT { get; set; }
        public char DV { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string eMail { get; set; }                
    }
}
