using Bookstore.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks();
        Task<BookDTO> CreateBook(BookDTO book);
    }
}
