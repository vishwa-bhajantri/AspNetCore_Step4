using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Project_Step4.Models;
using Project_Step4.Services;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace Project_Step4.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
    public class UsersDataCRUDController : ControllerBase
    {
        [HttpPost("CreateUserFromLocalHostAPI")]
        public async Task<IActionResult> CreateUserFromLocalHostAPI()
        {
          


            //you can give the detailsexplicitly 
            //var userDetails = new User()
            //{

            //};


            var details = new
            {
                Id = 1,
                FirstName = "vishwa"
            };

            string jsonData = JsonSerializer.Serialize(details);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");



            string url = "https://localhost:7046/api/Test/CreateUser";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }



        [HttpPut("UpdateUserFromLocalHostAPI")]
        public async Task<IActionResult> UpdateUserFromLocalHostAPI()
        {



            //you can give the detailsexplicitly 
            //var userDetails = new User()
            //{

            //};


            var details = new
            {
                Id = 1,
                FirstName = "Messi"
            };

            var userId = 1;

            string jsonData = JsonSerializer.Serialize(details);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");



            string url = $"https://localhost:7046/api/Test/UpdateUser?UserId={userId}";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("ApiKey", "MISARD123");

            HttpResponseMessage response = await client.PutAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            HttpStatusCode code = response.StatusCode;

            int code1 = (int)response.StatusCode;   //type conversion

            return Content(result, "application/json");
        }



        [HttpDelete("DeleteUserFromLocalHostAPI")]
        public async Task<IActionResult> DeleteUserFromLocalHostAPI([FromQuery] int UserId)
        {
            HttpClient client = new HttpClient();

            string url = $"https://localhost:7046/api/Test/DeleteUser?UserId={UserId}";


            client.DefaultRequestHeaders.Add("ApiKey", "MISARD123");

            HttpResponseMessage response = await client.DeleteAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            HttpStatusCode code = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode,result);   //type conversion
            }

            Response.StatusCode = (int)response.StatusCode;

            return Content(result, "application/json");
        }

    }
    
}
