﻿using System;
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
        public Authors Author { get; set; }
    }
}
