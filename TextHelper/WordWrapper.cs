using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextHelper
{
    public static class WordWrapper
    {
        /// <summary>
        /// Wraps the text into lines at the word boundary nearest to the lineWidth.
        /// </summary>
        /// <param name="lineWidth">Width of word wrapped text. (default is 80)</param>
        public static string WordWrap(this string  text, int lineWidth=80)
        {
            if (text.Length <= lineWidth) return text;

            var pattern = string.Format(@"(.{{1,{0}}})(\s+|$)", lineWidth);

            var lines = new List<string>();
            foreach(var line in text.Split('\n'))
            {
                lines.Add(Regex.Replace(line.Trim(), pattern, "$1\n").Trim());
            }

            return string.Join("\n", lines);
        }
    }
}
