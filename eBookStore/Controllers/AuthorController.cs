using DataAccess.DTO;
using eBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {

        private readonly HttpClient client = null;
        private string AuthorApiUrl = "";
        private static AuthorViewModel authorVM = new();

        public AuthorController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUrl = "https://localhost:7263/api/authors";

        }

        public async Task<IActionResult> Index(string? authorId, string? firstName, string? lastName, string? city)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(AuthorApiUrl);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<AuthorDTO>? list = JsonSerializer.Deserialize<List<AuthorDTO>>(strData, options);

                if (authorId != null)
                {
                    list = list?.Where(s => s.AuthorId == int.Parse(authorId)).ToList();
                }

                if (!string.IsNullOrEmpty(firstName))
                {
                    list = list?.Where(s => s.FirstName == firstName).ToList();
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    list = list?.Where(s => s.LastName == lastName).ToList();
                }

                if (!string.IsNullOrEmpty(city))
                {
                    list = list?.Where(s => s.City == city).ToList();
                }

                var data = new AuthorViewModel
                {
                    Author = { },
                    Message = authorVM.Message,
                    Authors = list
                };
                return View(data);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Author;
            var strContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsync(AuthorApiUrl + "/create", strContent);
            if (response.IsSuccessStatusCode)
            {
                authorVM.Message = "Add successfully!";
            }
            else
            {
                authorVM.Message = "Action failed!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(AuthorApiUrl + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                AuthorDTO? item = JsonSerializer.Deserialize<AuthorDTO>(strData, options);

                var data = new AuthorViewModel
                {
                    Author = item,
                    Message = authorVM.Message,
                    Authors = new List<AuthorDTO>()
                };
                return View(data);
            }
            else
            {
                authorVM.Message = "No Author found!";
                return RedirectToAction("Edit");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(AuthorViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Author;
            var token = HttpContext.Session.GetString("JwtToken");
            var strContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsync(AuthorApiUrl + "/" + input.Author.AuthorId, strContent);
            if (response.IsSuccessStatusCode)
            {
                authorVM.Message = "Update successfully!";
            }
            else
            {
                authorVM.Message = "Action failed!";
            }
            return RedirectToAction("Edit", new { id = data.AuthorId });
        }

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync(AuthorApiUrl + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                authorVM.Message = "Delete successfully!";
            }
            else
            {
                authorVM.Message = "Action failed!";
            }
            return RedirectToAction("Index");
        }
    }
}
