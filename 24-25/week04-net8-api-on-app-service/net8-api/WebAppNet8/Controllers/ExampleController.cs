using Microsoft.AspNetCore.Mvc;

namespace WebAppNet8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {

        [HttpGet(Name = "IFeelLucky")]
        public String Get()
        {
            return "Cloud computing is awesome!";
        }
    }
}
