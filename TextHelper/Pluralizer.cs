namespace TextHelper
{
    public static class Pluralizer
    {
        public static string Pluralize(this string text, int count, string plural=null)
        {
            if(count < 2) return text;
            return string.IsNullOrEmpty(plural) ? text + "s" : plural;
        }
    }
}
