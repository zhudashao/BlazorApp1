using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("It works");
        }
    }
}
