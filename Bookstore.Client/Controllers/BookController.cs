using Bookstore.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bookstore.Client.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookstoreConfiguration _bookstoreConfiguration;

        public BookController(IBookstoreConfiguration bookstoreConfiguration)
        {
            this._bookstoreConfiguration = bookstoreConfiguration;
        }        

        public async Task<IActionResult> Index()
        {
            var authors = new List<Book>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(this._bookstoreConfiguration.Get_API_URL("Book")))
                {
                    string api_response = await response.Content.ReadAsStringAsync();
                    authors = JsonConvert.DeserializeObject<List<Book>>(api_response);
                }
            }

            return View(authors);
        }

        public ViewResult AddBook() => View();

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            var received_book = new Book();

            var handler = new HttpClientHandler();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(this._bookstoreConfiguration.Get_API_URL("Book"), content))
                {
                    string api_response = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        received_book = JsonConvert.DeserializeObject<Book>(api_response);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, api_response);
                        return View(book);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
