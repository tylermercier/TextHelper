using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class ExcerptorFixture
    {
        const string HelloText = "hello";
        const string HelloWorldText = "hello world";

        [Test]
        public void Excerpt_ShouldReturnEmptyStringIfPhraseNotFound()
        {
            var result = HelloText.Excerpt("gaga");
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Excerpt_ShouldReturnWholeStringIfRadiusIsLargerThanLength()
        {
            var result = HelloText.Excerpt("ell");
            Assert.That(result, Is.EqualTo(HelloText));
        }

        [Test]
        public void Excerpt_ShouldUseEllipses()
        {
            var result = HelloWorldText.Excerpt(" ", 2);
            Assert.That(result, Is.EqualTo("...lo wo..."));
        }

        [Test]
        public void Excerpt_ShouldNotUseLeftOmissionIfLeftIndexIsLessThanOrEqualToZero()
        {
            var result = HelloWorldText.Excerpt("e", 2);
            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Excerpt_ShouldNotUserRightOmissionIfRightIndexIsGreaterThanOrEqualToTheTextLength()
        {
            var result = HelloWorldText.Excerpt("wo", 3);
            Assert.That(result, Is.EqualTo("...lo world"));
        }

        [Test]
        public void Excerpt_ShouldUseCustomOmission()
        {
            var result = HelloWorldText.Excerpt(" ", 2, ",,,");
            var expected = ",,,lo wo,,,";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Excerpt_should_be_case_insensitive()
        {
            var result = HelloText.Excerpt("L", 1);
            var expected = "...ell...";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
