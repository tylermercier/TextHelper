using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class ExcerptorFixture
    {
        [Test]
        public void Excerpt_ShouldReturnEmptyStringIfPhraseNotFound()
        {
            var result = "hello".Excerpt("gaga");
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Excerpt_ShouldReturnWholeStringIfRadiusIsLargerThanLength()
        {
            var result = "hello".Excerpt("ell");
            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void Excerpt_ShouldUseEllipses()
        {
            var result = "hello world".Excerpt(" ", 2);
            Assert.That(result, Is.EqualTo("...lo wo..."));
        }

        [Test]
        public void Excerpt_ShouldNotUseLeftOmissionIfLeftIndexIsLessThanOrEqualToZero()
        {
            var result = "hello world".Excerpt("e", 2);
            Assert.That(result, Is.EqualTo("hell..."));
        }

        [Test]
        public void Excerpt_ShouldNotUserRightOmissionIfRightIndexIsGreaterThanOrEqualToTheTextLength()
        {
            var result = "hello world".Excerpt("wo", 3);
            Assert.That(result, Is.EqualTo("...lo world"));
        }

        [Test]
        public void Excerpt_ShouldUseCustomOmission()
        {
            var result = "hello world".Excerpt(" ", 2, ",,,");
            var expected = ",,,lo wo,,,";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Excerpt_should_be_case_insensitive()
        {
            var result = "hello".Excerpt("L", 1);
            var expected = "...ell...";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
