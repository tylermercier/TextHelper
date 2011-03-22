using System.Text.RegularExpressions;

namespace TextHelper
{
    public static class SimpleFormatter
    {
        public static string ToSimpleFormat(this string text)
        {
            var result = text.Trim();
            var isWrapped = result.StartsWith("<p>") && result.EndsWith("</p>");

            result = result.Replace("\n\n", "</p>\n\n<p>");
            result = Regex.Replace(result, @"([^\n]\n)(?=[^\n])", "$1<br/>");

            return isWrapped ? result : string.Format("<p>{0}</p>", result);
        }

        internal  class NewLineReplacer
        {
            public string Text { get; set; }

            private  string OnMatch(Match match)
            {
                var matchIndex = match.Index;

                var prevChar = matchIndex > 0 ? Text.ToCharArray()[matchIndex - 1] : -1;
                var nextChar = matchIndex + 1 < Text.Length ? Text.ToCharArray()[matchIndex + 1] : -1;
                
                if(prevChar == '\n' || nextChar == '\n')
                {
                    return match.Value;
                }
                
                return match.Value + "<br/>";
            }
        }

        
    }
}
