using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Web;

namespace XcExample.Api.Sometext.Controllers
{
    /// <summary>
    /// controller for partying text
    /// </summary>
    [Route("api/{id:int}/[action]/{word:minlength(2)}/[controller]")]
    [ApiController]
    public class ConcatController : ControllerBase
    {
        private readonly ILogger<ConcatController> _logger;
        private readonly Handlers.IWords _words;

        /// <summary>
        /// Controller that puts text together
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="words"></param>
        public ConcatController(ILogger<ConcatController> logger, Handlers.IWords words)
        {
            _logger = logger;
            _words = words;
        }

        

        /// <summary>
        /// Get Some Text Together for a Party
        /// </summary>
        /// <param name="id"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTogether(Int16 id, string word)
        {
            _logger.LogInformation("TESTLOG: call to GetTogether()", id, HttpUtility.HtmlEncode(word));
            try
            {
                var thisWord = this._words.Lookup(id);
                var thisIndex = this._words.Lookup(word);
                return new List<string>()
                {
                    $"{thisWord} and {thisIndex}"
                }
                .ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TESTLOG: unable to find id or word");
                return NotFound();
            }
        }

        /// <summary>
        /// Get Some Text Together for a Party
        /// </summary>
        /// <param name="id" example="9987">word index</param>
        /// <param name="word" example="orange">indexed word</param>
        /// <param name="sentence" example="{  &quot;verb&quot;: &quot;Chase&quot;,  &quot;predicate&quot;: &quot;out of here&quot;,  &quot;punctuation&quot;: &quot;!&quot;}">words and puncuation</param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<string> GetTogether(Int16 id, string word, Model.Sentence sentence)
        {
            _logger.LogInformation("TESTLOG: call to GetTogether()", id, HttpUtility.HtmlEncode(word), sentence);
            var thisWord = this._words.Lookup(id);
            var thisIndex = this._words.Lookup(word);
            return new List<string>()
            {
                $"{sentence.Verb} {thisWord} and {thisIndex} {sentence.Predicate}{sentence.Punctuation}"
            }
            .ToArray();
        }
    }
}
