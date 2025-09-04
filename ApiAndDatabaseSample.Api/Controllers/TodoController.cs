using Microsoft.AspNetCore.Mvc;

namespace ApiAndDatabaseSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Ca marche" });
        }
    }
}
