using BusinessObject.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {

        private readonly HttpClient client = null;
        private string AuthorApiUrl = "";

        public AuthorController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUrl = "https://localhost:7263/api/authors";

        }

        [HttpGet("/authors")]
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(AuthorApiUrl);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Author>? list = JsonSerializer.Deserialize<List<Author>>(strData, options);

                var item = new AuthorViewModel
                {
                    Author = { },
                    Authors = list
                };
                return View(item);
            }
            return Unauthorized();
        }
    }
}
