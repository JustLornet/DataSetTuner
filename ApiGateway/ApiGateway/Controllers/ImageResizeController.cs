using ApiGateway.MessageBroker.Rabbit;
using ImageResizeMessages;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    public class ImageResizeController : Controller
    {
        private readonly IRabbitMqClient _rabbitMqClient;

        public ImageResizeController(IRabbitMqClient rabbitMqClient)
        {
            _rabbitMqClient = rabbitMqClient;
        }

        /// <summary>
        /// test
        /// </summary>
        [HttpGet]
        [Route("/TestAuth")]
        public async Task<IActionResult> TestHttp()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:45866");
            
            return new StatusCodeResult((int)response.StatusCode);
        }

        /// <summary>
        /// test
        /// </summary>
        public async Task<IActionResult> ProcessImages(string url, int width, int height, string pattern = "")
        {
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException(nameof(width), nameof(height));

            if (!Uri.TryCreate(url, UriKind.Absolute, out _)) throw new ArgumentOutOfRangeException(nameof(url));

            var message = new ResizeInfoMessage
            {
                Url = url,
                DestWidth = width,
                DestHeight = height,
                RegexPattern = pattern
            };

            try
            {
                _rabbitMqClient.SendMessage(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
    }
}
