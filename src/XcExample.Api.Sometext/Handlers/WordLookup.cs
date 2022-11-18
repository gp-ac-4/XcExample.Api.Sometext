using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XcExample.Api.Sometext.Handlers
{
    public class WordDictionary
    {
        public Dictionary<Int16, string> Words = new Dictionary<Int16, string>()
        {
            { 9987, "Gunnar" },
            { 32, "video" },
            { 1590, "orange"},
            { 22, "apple"}
        };

        public string Lookup(Int16 id)
        {
            if (this.Words.ContainsKey(id))
            {
                return this.Words[id];
            }

            throw new Exception("id not found");
        }

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
