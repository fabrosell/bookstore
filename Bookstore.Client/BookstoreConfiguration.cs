using System.Text;

namespace Bookstore.Client
{
    public class BookstoreConfiguration : IBookstoreConfiguration
    {
        //private readonly WebApplicationBuilder _builder;

        //public BookstoreConfiguration(WebApplicationBuilder builder)
        //{
        //    this._builder = builder;
        //}

        private readonly ConfigurationManager _configuration;

        public BookstoreConfiguration(ConfigurationManager configuration)
        {
            this._configuration = configuration;
        }

        public string Get_API_Base_URL()
        {
            var value = new StringBuilder(this._configuration["BookstoreAPIBaseUrl"] ?? "https://localhost:32769");

            if (value[value.Length - 1] == '/')
                value = value.Remove(value.Length - 1, 1);

            return value.ToString();
        }

        public string Get_API_URL(string relative_url)
        {
            if (string.IsNullOrEmpty(relative_url))
                return relative_url;

            return $"{this.Get_API_Base_URL()}/{relative_url}";
        }
    }
}
