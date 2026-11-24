using Microsoft.AspNetCore.Mvc;
using Project_Step4.Services;
using System.Net;

namespace Project_Step4.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("TestUsers")]
        public async Task<IActionResult> TestUsers()
        {
            var data = new List<string>() { "John", "Robert" };
            return Ok(data);
        }

        [HttpGet]
        [Route("GetUsers_Test")]
        public async Task<IActionResult> GetUsers_Test()
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


        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUsersFromExternalAPI")]
        public async Task<IActionResult> GetUsersFromExternalAPI()
        {
            //var users = _userService.GetUsers();

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/users");

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return Content(result,"application/json");
        }

        [HttpGet]
        [Route("GetUsersFromLocalHost")]
        public async Task<IActionResult> GetUsersFromLocalHost()
        {
            //var users = _userService.GetUsers();

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7046/api/Test/GetUsers");

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return Content(result, "application/json");
        }


        [HttpGet]
        [Route("GetUsersFromLocalHostQuery")]
        public async Task<IActionResult> GetUsersFromLocalHostQuery([FromQuery] int uid, [FromQuery] string uname)
        {
            //var users = _userService.GetUsers();

            HttpClient client = new HttpClient();

            string url = $"https://localhost:7046/api/Test/GetUsersByQuerry?userId={uid}&userName={uname}";

            HttpResponseMessage response = await client.GetAsync(url);

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return Content(result, "application/json");
        }

    }
}
