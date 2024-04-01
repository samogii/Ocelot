using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlayGround.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is playground 1");
        }
    }
}
