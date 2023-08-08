using Microsoft.AspNetCore.Mvc;

namespace SlowTestsSample.Controllers
{
    [ApiController]
    [Route("/slow-tests")]
    public class SlowTestsController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();

            var api1Endpoint1Task = HttpRequest(httpClient, "http://localhost:9091/api-1-endpoint-1");
            var api1Endpoint2Task = HttpRequest(httpClient, "http://localhost:9091/api-1-endpoint-2");
            await Task.WhenAll(api1Endpoint1Task, api1Endpoint2Task);

            await HttpRequest(httpClient, "http://localhost:9092/api-2-endpoint-1");

            return Ok();
        }

        public async Task HttpRequest(HttpClient httpClient, string url)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            await httpClient.SendAsync(request);
        }
    }
}
