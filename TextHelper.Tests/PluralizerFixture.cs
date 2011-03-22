using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class PluralizerFixture
    {
        [Test, Sequential]
        public void Pluralize_should_not_pluralize_when_count_is_less_than_2([Values(0, 1)] int count)
        {
            var result = "apple".Pluralize(count);

            Assert.That(result, Is.EqualTo("apple"));
        }

        [Test]
        public void Pluralize_should_pluraize_when_count_is_greater_than_1()
        {
            var result = "apple".Pluralize(2);
            Assert.That(result, Is.EqualTo("apples"));
        }

        [Test]
        public void Pluralize_should_use_given_plural()
        {
            var result = "apple".Pluralize(2, "applex");
            Assert.That(result, Is.EqualTo("applex"));
        }
    }
}
