using System;

namespace TextHelper
{
    public static class Excerptor
    {
        public  static string Excerpt(this string text, string phrase, int radius=100, string omission="...")
        {
            var phraseIndex = text.IndexOf(phrase, StringComparison.InvariantCultureIgnoreCase);
            if (phraseIndex == -1) return string.Empty;
            if (radius >= text.Length / 2) return text;

            return GetExcerptWithOmission(text, phrase, phraseIndex, radius, omission);
        }

        private static string GetExcerptWithOmission(string text, string phrase, int phraseIndex, int radius, string omission)
        {
            var leftIndex = phraseIndex - radius;
            if(leftIndex < 0)
            {
                leftIndex = 0;
            }

            var rightIndex = phraseIndex + phrase.Length + radius;
            if (rightIndex > text.Length)
            {
                rightIndex = text.Length;
            }

            var excerpt = text.Substring(leftIndex, rightIndex - leftIndex);

            var leftOmission = leftIndex > 0 ? omission : string.Empty;
            var rightOmission = rightIndex < text.Length ? omission : string.Empty;
            return string.Format("{0}{1}{2}", leftOmission, excerpt, rightOmission);
        }
    }
}
