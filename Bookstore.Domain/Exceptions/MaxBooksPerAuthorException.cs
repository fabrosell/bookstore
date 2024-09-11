using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Exceptions
{
    public class MaxBooksPerAuthorException : BookstoreException
    {
        public MaxBooksPerAuthorException(string message) : base(message) 
        { 
        }
    }
}
