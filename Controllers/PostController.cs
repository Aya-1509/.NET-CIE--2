// Import Post model
using Doc_Hospital_Appointment_Management_System.Models;

using Microsoft.AspNetCore.Mvc;

// Used to convert JSON data into C# objects
using System.Text.Json;

namespace Doc_Hospital_Appointment_Management_System.Controllers
{
    // Controller for retrieving posts
    public class PostController : Controller
    {
        // HttpClientFactory is used to create HttpClient
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor injection
        public PostController(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Async action to retrieve posts
        public async Task<IActionResult> Index()
        {
            // Create HttpClient
            var client =
                _httpClientFactory.CreateClient();

            // Send asynchronous GET request
            var response = await client.GetAsync(
                "https://jsonplaceholder.typicode.com/posts"
            );

            // Throw an exception if request fails
            response.EnsureSuccessStatusCode();

            // Read response content as a string asynchronously
            var json =
                await response.Content.ReadAsStringAsync();

            // Convert JSON into a list of Post objects
            var posts =
                JsonSerializer.Deserialize<List<Post>>(
                    json,
                    new JsonSerializerOptions
                    {
                        // Ignore uppercase/lowercase differences
                        PropertyNameCaseInsensitive = true
                    }
                );

            // Send posts to the view
            return View(
                posts ?? new List<Post>()
            );
        }
    }
}