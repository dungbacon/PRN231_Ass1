using DataAccess.DTO;
using eBookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {

        private readonly HttpClient client = null;
        private string ApiUrl = "";
        private static PublisherViewModel viewmodel = new();

        public PublisherController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7263/api/publishers";

        }
        public async Task<IActionResult> Index(string PubId, string PubName, string City, string State, string Country)
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
                List<PublisherDTO>? list = JsonSerializer.Deserialize<List<PublisherDTO>>(strData, options);

                if (!string.IsNullOrEmpty(PubId))
                {
                    list = list?.Where(s => s.PubId == int.Parse(PubId)).ToList();
                }

                if (!string.IsNullOrEmpty(PubName))
                {
                    list = list?.Where(s => s.PubName == PubName).ToList();
                }

                if (!string.IsNullOrEmpty(City))
                {
                    list = list?.Where(s => s.City == City).ToList();
                }

                if (!string.IsNullOrEmpty(State))
                {
                    list = list?.Where(s => s.State == State).ToList();
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    list = list?.Where(s => s.Country == Country).ToList();
                }

                var data = new PublisherViewModel
                {
                    Publisher = { },
                    Message = viewmodel.Message,
                    Publishers = list
                };
                return View(data);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher(PublisherViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Publisher;
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
                PublisherDTO? item = JsonSerializer.Deserialize<PublisherDTO>(strData, options);

                var data = new PublisherViewModel
                {
                    Publisher = item,
                    Message = viewmodel.Message,
                    Publishers = new List<PublisherDTO>()
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
        public async Task<IActionResult> EditPublisher(PublisherViewModel input)
        {
            if (input is null) return BadRequest();
            var data = input.Publisher;
            var token = HttpContext.Session.GetString("JwtToken");
            var strContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsync(ApiUrl + "/" + input.Publisher.PubId, strContent);
            if (response.IsSuccessStatusCode)
            {
                viewmodel.Message = "Update successfully!";
            }
            else
            {
                viewmodel.Message = "Action failed!";
            }
            return RedirectToAction("Edit", new { id = data.PubId });
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
