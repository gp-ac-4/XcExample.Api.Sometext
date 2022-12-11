using Microsoft.AspNetCore.Mvc;
using XcExample.Api.Sometext.Handlers;

namespace XcExample.Api.Sometext.Controllers
{
    /// <summary>
    /// stuff with words
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WordsController : ControllerBase
    {
        private readonly ILogger<ConcatController> _logger;
        private readonly Handlers.IWords _words;

        /// <summary>
        /// Controller that puts text together
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="words"></param>
        public WordsController(ILogger<ConcatController> logger, Handlers.IWords words)
        {
            _logger = logger;
            _words = words;
        }

        /// <summary>
        /// lookup a word, used to illistrate optioinal parameter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>list of words</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Lookup(Int16? filter = null)
        {
            _logger.LogInformation("TESTLOG: call to Lookup()", filter);
            try
            {
                // when no value given, give a list
                if (filter == null)
                {
                    return ((WordDictionary)this._words).Words.Select(o => o.Value).ToList();
                }

                // when filtered, lookup word
                return new List<string>()
                {
                    this._words.Lookup(filter ?? 0)
                }
                .ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "unable to find id or word");
                return NotFound();
            }
        }
    }
}
