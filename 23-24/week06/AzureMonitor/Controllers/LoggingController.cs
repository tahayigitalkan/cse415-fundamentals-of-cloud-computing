using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AzureMonitor.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoggingController : ControllerBase
    {
     
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetItems")]
        public IEnumerable<long> GetItems()
        {
            _logger.LogDebug("Debug: GetItems called");

            _logger.LogInformation("Information: GetItems called");

            var items = Enumerable.Range(1, 5).Select(index => new Random().NextInt64()).ToArray();

            _logger.LogTrace($"Trace: Items{JsonConvert.SerializeObject(items)}");

            return items;
        }


        
        [HttpGet(Name = "GetItemsError")]
        public IActionResult GetItemsError()
        {
            _logger.LogInformation("Information: GetItemsError called");

            var ex = new Exception("An error occured while generating items");
            _logger.LogError(ex.StackTrace);

            throw ex;
        }
        
        [HttpGet(Name = "GetItemsNotFound")]
        public IActionResult GetItemsNotFound()
        {
            _logger.LogInformation("Information: GetItemsNotFound called");

            _logger.LogWarning("Warning: Items could not be found");

            return new NotFoundResult();
        }
        
    }
}