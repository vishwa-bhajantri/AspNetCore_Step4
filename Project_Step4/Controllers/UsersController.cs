using Microsoft.AspNetCore.Mvc;

namespace Project_Step4.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("TestUsers")]
        public async Task<IActionResult> TestUsers()
        {
            var data = new List<string>() { "John", "Robert" };
            return Ok(data);
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {

            var request = HttpContext.Request;   //Request Represents the incoming HTTP Request from the client

            var schemeName = request.Scheme;

            var protocolName = request.Protocol;

            var pathName = request.Path;


            //var data = new List<string>() { "John", "Robert" };

            var details = new
            {
                schemeName = schemeName,
                protocol = protocolName,
                path = pathName
            };

            return Ok(details);
        }
    }
}
