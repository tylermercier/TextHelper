namespace TextHelper
{
    public static class Pluralizer
    {
        /// <summary>
        /// Attempts to pluralize the singular word unless count is 1.
        /// </summary>
        /// <param name="count">The number of things</param>
        /// <param name="plural">If plural is supplied, it will use that when count is > 1, otherwise it will add an 's' to the end</param>
        public static string Pluralize(this string text, int count, string plural=null)
        {
            if(count < 2) return text;
            return string.IsNullOrEmpty(plural) ? text + "s" : plural;
        }
    }
}
