namespace XcExample.Api.Sometext.Model
{
    /// <summary>
    /// building to say something
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// Action word
        /// </summary>
        /// <example>Send</example>
        public string Verb { get; set; }
        /// <summary>
        /// last half of something to say
        /// </summary>
        /// <example>to the Moon</example>
        public string Predicate { get; set; }
        /// <summary>
        /// classify what you want to say
        /// </summary>
        /// <example>!</example>
        public char Punctuation { get; set; }
    }
}
