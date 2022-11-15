using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using XcExample.Api.Sometext.Model;

namespace XcExample.Api.Sometext.Controllers
{
    [Route("api/{id:int}/[action]/{word:minlength(2)}/[controller]")]
    [ApiController]
    public class ConcatController : ControllerBase
    {
        private readonly ILogger<ConcatController> _logger;

        public ConcatController(ILogger<ConcatController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> GetTogether(Int16 id, string word)
        {
            return new List<string>()
            {
                $"{id} and {word}"
            }
            .ToArray();
        }

        [HttpPost]
        public IEnumerable<string> GetTogether(Int16 id, string word, Sentence sentence)
        {
            return new List<string>()
            {
                $"{sentence.Verb} {id} and {word} {sentence.Predicate}{sentence.Punctuation}"
            }
            .ToArray();
        }
    }
}
