using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class SimpleFormatterFixture
    {
        [Test]
        public void ToSimpleFormat_should_wrap_inside_p()
        {
            var result = "hello".ToSimpleFormat();
            var expected = "<p>hello</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_not_wrap_if_wrapped()
        {
            var result = "<p>hello world</p>".ToSimpleFormat();
            var expected = "<p>hello world</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_newline_with_br_tag()
        {
            var result = "hello\n world".ToSimpleFormat();
            var expected = "<p>hello\n<br/> world</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_two_newlines_with_new_paragraph()
        {
            var result = "hello\n\n world".ToSimpleFormat();
            var expected = "<p>hello</p>\n\n<p> world</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_two_leading_newlines_with_new_paragraph()
        {
            var result = "\n\n world".ToSimpleFormat();
            var expected = "<p>world</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_one_leading_newline_with_new_paragraph()
        {
            var result = "\n world".ToSimpleFormat();
            var expected = "<p>world</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_two_trailing_newline_with_new_paragraph()
        {
            var result = "hello \n\n".ToSimpleFormat();
            var expected = "<p>hello</p>";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToSimpleFormat_should_replace_one_trailing_newline_with_new_paragraph()
        {
            var result = "hello \n".ToSimpleFormat();
            var expected = "<p>hello</p>";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
