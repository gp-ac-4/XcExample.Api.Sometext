using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace XcExample.Api.Sometext.Controllers
{
    /// <summary>
    /// a test controller for showing the headers passed in
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TestHeadersController : ControllerBase
    {

        private readonly ILogger<SomeTextController> _logger;

        /// <summary>
        /// Instance of header test controller
        /// </summary>
        /// <param name="logger"></param>
        public TestHeadersController(ILogger<SomeTextController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// simple header exposer so you can see what is going on
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogDebug("TESTLOG: call to Get()");
            var headers = new List<string>();
            foreach (var headerPair in Request.Headers)
            {
                headers.Add($"{headerPair.Key}:{headerPair.Value}");
            }
            return headers.ToArray();
        }
    }
}
