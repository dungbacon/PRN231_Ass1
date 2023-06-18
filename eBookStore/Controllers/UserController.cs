using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient client = null;
        private string UserApiUrl = "";
        public UserController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUrl = "https://localhost:7263/api";
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserRequestDTO p)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(UserApiUrl + "/login", p);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                UserResponseDTO? user = JsonSerializer.Deserialize<UserResponseDTO>(content, options);
                string? token = user.AccessToken;
                HttpContext.Session.SetString("JwtToken", token);
                return RedirectToAction("Index", "Author");
            }
            else
            {
                ViewData["Message"] = "Incorrect UserId or Password!";
                return View(nameof(Login));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestDTO info)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(UserApiUrl + "/register", info);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Register successfully! Please sign in~";
                return View(nameof(Login));
            }
            else
            {
                return View(nameof(Register));
            }

        }
    }
}
