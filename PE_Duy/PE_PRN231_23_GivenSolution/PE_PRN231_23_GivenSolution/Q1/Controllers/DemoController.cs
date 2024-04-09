using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Demo()
        {
            return Ok("Hello");
        }
    }
}
