using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain
{
    public interface IBookstoreConfiguration
    {
        int Get_Max_Books_Per_Author();
    }
}
