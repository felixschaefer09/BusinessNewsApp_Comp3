using BusinessNewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessNewsApp.Models;

public class NewsController : Controller
{
    public async Task<IActionResult> Index()
    {
        string apiKey = "578760f5f71f402888e5d27f6ea1a40b";  // replace with your NewsAPI key
        string url = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={apiKey}";

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "BusinessNewsApp");

        var client = new HttpClient();
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            string errorDetails = await response.Content.ReadAsStringAsync();
            return Content($"API call failed: {response.StatusCode}\n{errorDetails}");
        }

        var json = await response.Content.ReadAsStringAsync();
        var news = JsonConvert.DeserializeObject<NewsResponse>(json);

        return View(news.Articles);
    }
}
