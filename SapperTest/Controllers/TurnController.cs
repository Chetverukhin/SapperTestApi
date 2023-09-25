using Microsoft.AspNetCore.Mvc;
using SapperTest.Mdels;

namespace SapperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnController : Controller
    {
        [HttpPost]
        public IActionResult Index(TurnRequestModel userChoice)
        {
            return Ok();
        }
        
    }
}
