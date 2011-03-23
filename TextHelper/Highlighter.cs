using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextHelper
{
    public static class Highlighter
    {
        /// <summary>
        /// <seealso cref="Highlight(this string, string, string)"/>
        /// </summary>
        /// <param name="phrases">The list of phrases to highlight</param>
        public static string Highlight(this string text, IList<string> phrases, string highlighter = "<strong class=\"highlighted\">{0}</strong>")
        {
            return phrases.Aggregate(text, (current, phrase) => current.Highlight(phrase, highlighter));
        }

        /// <summary>
        /// Highlights one or more phrases everywhere in text by inserting it into a highlighter string.
        /// </summary>
        /// <param name="phrase">The phrase to highlight</param>
        /// <param name="highlighter">A string formatter where {0} will be replaced by the phrase (defaults to &lt;strong class="highlighted"&gt;{0}&lt;/strong&gt;)</param>
        public static string Highlight(this string text, string phrase, string highlighter="<strong class=\"highlighted\">{0}</strong>")
        {
            if (text.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase) == -1) return text;

            var replacer = new HighlightReplacer {Format = highlighter};

            return Regex.Replace(text, phrase, replacer.OnPhraseMatch, RegexOptions.IgnoreCase);
        }

        internal class HighlightReplacer
        {
            public string Format { get; set; }     

            public string OnPhraseMatch(Match match)
            {
                return string.Format(Format, match.Value);
            }
        }
    }
}
