using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class TruncatorFixture
    {
        const string HelloText = "hello";
        const string HelloWorldText = "hello world";

        [Test]
        public void Truncate_ShouldNotChangeIfActualLengthIsLessOrEqual()
        {
            var result = HelloText.Truncate(5);

            Assert.That(result, Is.EqualTo(HelloText));
        }

        [Test]
        public void Truncate_ShouldAddEllipsesIfActualLengthIsGreater()
        {
            var result = HelloText.Truncate(4);

            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Truncate_ShouldUseTheCustomOmmission()
        {
            var result = HelloText.Truncate(4, "... continued");

            Assert.That(result, Is.EqualTo("hell... continued"));
        }

        [Test]
        public void Truncate_ShouldNotUseSeparatorIfNoneFound()
        {
            var result = HelloText.Truncate(4, separator: " ");
            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Truncate_ShouldUseSeparatorIfFound()
        {
            var result = HelloWorldText.Truncate(8, separator: " ");
            Assert.That(result, Is.EqualTo("hello..."));
        }

        [Test]
        public void Truncate_ShouldUseCustomOmmissionWithSeparator()
        {
            var result = HelloWorldText.Truncate(8, "<cut>", " ");
            Assert.That(result, Is.EqualTo("hello<cut>"));
        }
    }
}
