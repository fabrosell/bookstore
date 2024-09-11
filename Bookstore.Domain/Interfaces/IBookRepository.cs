﻿using Bookstore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksByAuthor(int author_id);
        Task<Book> Create(Book book);
    }
}
