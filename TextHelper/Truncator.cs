namespace TextHelper
{
    public static class Truncator
    {

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
