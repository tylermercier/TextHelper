using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class WordWrapperFixture
    {
        [Test]
        public void WordWrap_should_not_wrap_if_length_less_than_text_length()
        {
            var result = "hello world".WordWrap();
            Assert.That(result, Is.EqualTo("hello world"));
        }

        [Test]
        public void WordWrap_should_wrap_single_line_text()
        {
            var result = "hello world".WordWrap(7);
            Assert.That(result, Is.EqualTo("hello\nworld"));
        }

        [Test]
        public void WordWrap_should_wrap_multi_line_text()
        {
            var result = "hello world \nhere I come\nagain".WordWrap(7);
            Assert.That(result, Is.EqualTo("hello\nworld\nhere I\ncome\nagain"));
        }
    }
}
