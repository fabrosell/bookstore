﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Exceptions
{
    public class InvalidAuthorException : BookstoreException
    {
        public InvalidAuthorException(string message) : base(message)
        {

        }
    }
}
