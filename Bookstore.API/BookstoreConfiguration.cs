using Bookstore.Domain;
using Microsoft.Extensions.Configuration;

namespace Bookstore.API
{
    public class BookstoreConfiguration : IBookstoreConfiguration
    {
        private const int Default_Max_Books_Per_Author = 10;        

        private readonly WebApplicationBuilder _builder;

        public BookstoreConfiguration(WebApplicationBuilder builder)
        {
            this._builder = builder;
        }

        public int Get_Max_Books_Per_Author()
        {
            var value = this._builder.Configuration["Max_Books_Per_Author"];

            if (Int32.TryParse(value, out int Max_Books_Per_Author))
                return Max_Books_Per_Author;
            else
                return Default_Max_Books_Per_Author;
        }
    }
}
