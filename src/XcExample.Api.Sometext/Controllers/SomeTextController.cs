using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace XcExample.Api.Sometext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeTextController : ControllerBase
    {

        private readonly ILogger<SomeTextController> _logger;

        public SomeTextController(ILogger<SomeTextController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new List<string>()
            {
                "Yup, a string"
            }
            .ToArray();
        }
    }
}
