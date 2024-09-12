using Bookstore.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Bookstore.Client.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookstoreConfiguration _bookstoreConfiguration;

        public AuthorController(IBookstoreConfiguration bookstoreConfiguration)
        {
            this._bookstoreConfiguration = bookstoreConfiguration;
        }

        public async Task<IActionResult> Index()
        {
            var authors = new List<Author>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(this._bookstoreConfiguration.Get_API_URL("Author")))
                {
                    string api_response = await response.Content.ReadAsStringAsync();
                    authors = JsonConvert.DeserializeObject<List<Author>>(api_response);
                }
            }

            return View(authors);
        }

        public ViewResult AddAuthor() => View();

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);
            
            var received_author = new Author();

            var handler = new HttpClientHandler();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(this._bookstoreConfiguration.Get_API_URL("Author"), content))
                {                    
                    string api_response = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        received_author = JsonConvert.DeserializeObject<Author>(api_response);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, api_response);
                        return View(author);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
