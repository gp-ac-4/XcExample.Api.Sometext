using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace XcExample.Api.Sometext.Controllers
{
    /// <summary>
    /// simple text endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SomeTextController : ControllerBase
    {
        private readonly ILogger<SomeTextController> _logger;
        /// <summary>
        /// instance of text endpoint
        /// </summary>
        /// <param name="logger"></param>
        public SomeTextController(ILogger<SomeTextController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// just get some text
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("call to Get() log", DateTime.UtcNow.ToLongTimeString());
            return new List<string>()
            {
                "Yup, a string"
            }
            .ToArray();
        }
    }
}
