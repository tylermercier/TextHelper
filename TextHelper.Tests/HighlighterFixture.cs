using System.Collections.Generic;
using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class HighlightorFixture
    {
        [Test]
        public void Hightlight_should_not_highlight_if_phrase_not_found()
        {
            var result = "hello".Highlight("not found");

            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void Hightlight_should_highlight_if_phrase_found()
        {
            var result = "hello".Highlight("l");

            var expectedResult = @"he<strong class=""highlighted"">l</strong><strong class=""highlighted"">l</strong>o";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Hightlight_should_highlight_with_custom_highlighter()
        {
            var result = "hello".Highlight("l", "<b>{0}</b>");

            var expectedResult = @"he<b>l</b><b>l</b>o";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public  void Highlight_should_take_multiple_phrases()
        {
            var phrases = new List<string> {"Hello", "World"};
            var result = "hello world".Highlight(phrases);

            var expected = @"<strong class=""highlighted"">hello</strong> <strong class=""highlighted"">world</strong>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public  void Highlight_should_match_case_insensitive()
        {
            var result = "hello".Highlight("HELLO");
            var expected = @"<strong class=""highlighted"">hello</strong>";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
