using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace XcExample.Api.Sometext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestHeadersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var headers = new List<string>();
            foreach (var headerPair in Request.Headers)
            {
                headers.Add($"{headerPair.Key}:{headerPair.Value}");
            }
            return headers.ToArray();
        }
    }
}
