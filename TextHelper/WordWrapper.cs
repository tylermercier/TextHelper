using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextHelper
{
    public static class WordWrapper
    {
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
