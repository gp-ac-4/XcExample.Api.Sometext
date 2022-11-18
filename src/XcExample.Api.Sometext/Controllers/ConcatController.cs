using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        /// <summary>
        /// Controller that puts text together
        /// </summary>
        /// <param name="logger"></param>
        public ConcatController(ILogger<ConcatController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Some Text Together for a Party
        /// </summary>
        /// <param name="id"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> GetTogether(Int16 id, string word)
        {
            _logger.LogInformation("call to GetTogether()", id, word);
            return new List<string>()
            {
                $"{id} and {word}"
            }
            .ToArray();
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
            _logger.LogInformation("call to GetTogether()", id, word, sentence);
            return new List<string>()
            {
                $"{sentence.Verb} {id} and {word} {sentence.Predicate}{sentence.Punctuation}"
            }
            .ToArray();
        }
    }
}
