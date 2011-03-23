using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextHelper
{
    public enum LinkMode
    {
        All,
        Url,
        Email
    }

    public static class AutoLinker
    {
        /// <summary>
        /// Turns all URLs and e-mail addresses into clickable links.
        /// </summary>
        /// <param name="htmlAttributes">Adds HTML attributes to the links.</param>
        /// <param name="textReplacer">Lambda expression to change what text is shown inside the link tag.</param>
        /// <param name="linkMode">Option to limit what should be linked.</param>
        public static string AutoLink(this string text, IDictionary<string, string> htmlAttributes=null, Func<string, string> textReplacer=null, LinkMode linkMode=LinkMode.All)
        {
            textReplacer = textReplacer ?? (x => x);
            var replacer = new AutoLinkReplacer(htmlAttributes, textReplacer, linkMode);
            return replacer.Replace(text);
        }
       
        internal class AutoLinkReplacer
        {
            public LinkMode LinkMode { get; set; }
            public IDictionary<string, string> HtmlAttributes { get; set; }
            public Func<string, string> TextReplacer { get; set; }
            private const string UrlPattern = @"http(s?)\:\/\/(\S*)";
            private const string EmailPattern = @"[\S|^\@]*\@[^\.]*\.(\S*)";
            
            public AutoLinkReplacer(IDictionary<string, string> dictionary, Func<string, string> textReplacer, LinkMode linkMode)
            {
                LinkMode = linkMode;
                HtmlAttributes = dictionary;
                TextReplacer = textReplacer;
            }

            public string Replace(string text)
            {
                var result = text;
                
                if (LinkMode == LinkMode.All || LinkMode == LinkMode.Url)
                {
                    result = Regex.Replace(result, UrlPattern, OnUrlMatch);
                }

                if (LinkMode == LinkMode.All || LinkMode == LinkMode.Email)
                {
                    result = Regex.Replace(result, EmailPattern, OnEmailMatch);
                }
                return result;
            }

            static string GetAttributesFromDictionary(IDictionary<string, string> dictionary)
            {
                if (dictionary == null || dictionary.Count == 0) return string.Empty;
                var stringAttributes = new List<string>();
                foreach (var key in dictionary.Keys)
                {
                    stringAttributes.Add(string.Format(@"{0}=""{1}""", key, dictionary[key]));
                }
                return " " + string.Join(" ", stringAttributes);
            }

            public string OnUrlMatch(Match match)
            {
                return GetHyperlink(@"<a href=""{0}""{1}>{2}</a>", match.Value);
            }

            public string OnEmailMatch(Match match)
            {
                return GetHyperlink(@"<a href=""mailto:{0}""{1}>{2}</a>", match.Value);
            }

            private string GetHyperlink(string format, string link)
            {
                return string.Format(format, link, GetAttributesFromDictionary(HtmlAttributes), GetTextFor(link));
            }

            public string GetTextFor(string link)
            {
                return TextReplacer(link);
            }
        }
    }
}
