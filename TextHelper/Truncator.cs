namespace TextHelper
{
    public static class Truncator
    {
        /// <summary>
        /// Truncates a given text after a given length.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength">Length of truncated text (default is 30)</param>
        /// <param name="ommision">The last characters to be replaced with if truncated. (defaults to "...").</param>
        /// <param name="separator">Include if you want to truncate text at a natural break. For example, " " will truncate at word boundaries</param>
        /// <returns></returns>
        public static string Truncate (this string text, int maxLength=30, string ommision="...", string separator="")
        {
            if (string.IsNullOrEmpty(text)) return text;

            var result = text;
            if (text.Length > maxLength)
            {
                result = text.Substring(0, maxLength);
                result = ApplySeparator(result, separator);
                result += ommision;
            }

            return result;
        }

        private static string ApplySeparator(string text, string separator)
        {
            if (string.IsNullOrEmpty((separator)))
            {
                return text;
            }

            var indexOfSeparator = text.LastIndexOf(separator);
            return indexOfSeparator == -1 ? text : text.Substring(0, indexOfSeparator);
        }
    }
}
