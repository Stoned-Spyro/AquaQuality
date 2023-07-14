using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AquaQuality.WEB.Controllers
{
    [Authorize]
    [Route("api/secured")]
    public class TestSecureController : MainController
    {
        [HttpGet]
        public IActionResult GetSecuredData()
        {
            return Ok("This is secured data");
        }
    }
}
