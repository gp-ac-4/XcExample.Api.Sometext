using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XcExample.Api.Sometext.Handlers
{
    /// <summary>
    /// class for playing with a word dictionary to inject the idea of 'valid' data
    /// </summary>
    public class WordDictionary : IWords
    {
        public Dictionary<Int16, string> Words = new Dictionary<Int16, string>()
        {
            { 9987, "Gunnar" },
            { 32, "video" },
            { 1590, "orange"},
            { 22, "apple"}
        };

        /// <summary>
        /// look up a word by index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Lookup(Int16 id)
        {
            if (this.Words.ContainsKey(id))
            {
                return this.Words[id];
            }

            throw new Exception("id not found");
        }

        /// <summary>
        /// lookup an index by word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Lookup(string word)
        {
            if (this.Words.Values.Contains(word))
            {
                return Words.FirstOrDefault(o => o.Value == word).Key;
            }

            throw new Exception("value not found");
        }
    }
}
