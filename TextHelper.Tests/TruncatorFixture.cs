using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class TruncatorFixture
    {
        [Test]
        public void Truncate_should_not_change_if_actual_length_is_less_or_equal()
        {
            var result = "hello".Truncate(5);

            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void Truncate_should_add_ellipses_if_actual_length_is_greater()
        {
            var result = "hello".Truncate(4);

            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Truncate_should_use_the_custom_omission()
        {
            var result = "hello".Truncate(4, "... continued");

            Assert.That(result, Is.EqualTo("hell... continued"));
        }

        [Test]
        public void Truncate_should_not_use_separator_if_none_found()
        {
            var result = "hello".Truncate(4, separator: " ");
            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Truncate_should_use_separator_if_found()
        {
            var result = "hello world".Truncate(8, separator: " ");
            Assert.That(result, Is.EqualTo("hello..."));
        }

        [Test]
        public void Truncate_should_use_custom_omission_with_separator()
        {
            var result = "hello world".Truncate(8, "<cut>", " ");
            Assert.That(result, Is.EqualTo("hello<cut>"));
        }
    }
}
