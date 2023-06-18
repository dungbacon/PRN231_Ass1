using DataAccess.DTO;
using eBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient client = null;
        private string ApiUrl = "";
        private static BookViewModel viewmodel = new();

        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7263/api/books";

        }
        public async Task<IActionResult> Index(string Title, string Price)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<BookDTO>? list = JsonSerializer.Deserialize<List<BookDTO>>(strData, options);

                if (!string.IsNullOrEmpty(Title))
                {
                    list = list?.Where(s => s.Title == Title).ToList();
                }

                if (!string.IsNullOrEmpty(Title))
                {
                    list = list?.Where(s => s.PubId == decimal.Parse(Price)).ToList();
                }

                var data = new BookViewModel
                {
                    Book = { },
                    Message = viewmodel.Message,
                    Books = list
                };
                return View(data);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Book;
            var strContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsync(ApiUrl + "/create", strContent);
            if (response.IsSuccessStatusCode)
            {
                viewmodel.Message = "Add successfully!";
            }
            else
            {
                viewmodel.Message = "Action failed!";
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(ApiUrl + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                BookDTO? item = JsonSerializer.Deserialize<BookDTO>(strData, options);

                var data = new BookViewModel
                {
                    Book = item,
                    Message = viewmodel.Message,
                    Books = new List<BookDTO>()
                };
                return View(data);
            }
            else
            {
                viewmodel.Message = "No item found!";
                return RedirectToAction("Edit");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(BookViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Book;
            var token = HttpContext.Session.GetString("JwtToken");
            var strContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsync(ApiUrl + "/" + input.Book.BookId, strContent);
            if (response.IsSuccessStatusCode)
            {
                viewmodel.Message = "Update successfully!";
            }
            else
            {
                viewmodel.Message = "Action failed!";
            }
            return RedirectToAction("Edit", new { id = data.BookId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync(ApiUrl + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                viewmodel.Message = "Delete successfully!";
            }
            else
            {
                viewmodel.Message = "Action failed!";
            }
            return RedirectToAction("Index");
        }
    }
}
