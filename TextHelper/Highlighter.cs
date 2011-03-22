using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextHelper
{
    public static class Highlighter
    {
        public static string Highlight(this string text, IList<string> phrases, string highlighter = "<strong class=\"highlighted\">{0}</strong>")
        {
            return phrases.Aggregate(text, (current, phrase) => current.Highlight(phrase, highlighter));
        }

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
