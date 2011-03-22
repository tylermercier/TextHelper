using System.Collections.Generic;
using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class HighlightorFixture
    {
        const string HelloText = "hello";
        const string HelloWorldText = "hello world";

        [Test]
        public void Hightlight_ShouldNotHighlightIfPhraseNotFound()
        {
            var result = HelloText.Highlight("not found");

            Assert.That(result, Is.EqualTo(HelloText));
        }

        [Test]
        public void Hightlight_ShouldHighlightIfPhraseFound()
        {
            var result = HelloText.Highlight("l");

            var expectedResult = @"he<strong class=""highlighted"">l</strong><strong class=""highlighted"">l</strong>o";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Hightlight_ShouldHighlightWithCustomHighlighter()
        {
            var result = HelloText.Highlight("l", "<b>{0}</b>");

            var expectedResult = @"he<b>l</b><b>l</b>o";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public  void Highlight_should_take_multiple_phrases()
        {
            var phrases = new List<string> {"Hello", "World"};
            var result = HelloWorldText.Highlight(phrases);

            var expected = @"<strong class=""highlighted"">hello</strong> <strong class=""highlighted"">world</strong>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public  void Highlight_should_match_case_insensitive()
        {
            var result = HelloText.Highlight("HELLO");
            var expected = @"<strong class=""highlighted"">hello</strong>";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
