using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Exceptions
{
    public class AuthorNotFoundException : BookstoreException
    {
        public AuthorNotFoundException(string message) : base(message)
        {
        }
    }
}
