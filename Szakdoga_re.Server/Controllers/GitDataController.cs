using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Szakdoga_re.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitDataController : ControllerBase
    {
        [HttpGet(Name = "GetGitData")]
        [Produces("application/json")]
        public IEnumerable<GitData> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://gitlab.com/api/v4/projects/Laci2058%2Ftesztprojekt/issues?private_token=");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var result = client.GetAsync(client.BaseAddress).Result;
            var json = result.Content.ReadAsStringAsync().Result;


            return JsonConvert.DeserializeObject<GitData[]>(json);
        }

    }
}
