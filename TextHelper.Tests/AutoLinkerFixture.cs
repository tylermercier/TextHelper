using System.Collections.Generic;
using NUnit.Framework;

namespace TextHelper.Tests
{
    [TestFixture]
    public class AutoLinkerFixture
    {
        class Person
        {
            public string controller { get; set; }
        }
        [Test]
        public void AutoLink_should_not_do_anything_if_no_linkable_found()
        {            
            var result = "hello".AutoLink();
            Assert.That(result, Is.EqualTo("hello"));
        }

        [Test]
        public void AutoLink_should_convert_urls_to_hyperlinks()
        {
            var result = "Go to http://www.asp.net to see more".AutoLink();
            var expected = @"Go to <a href=""http://www.asp.net"">http://www.asp.net</a> to see more";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_convert_https_urls_to_hyperlinks()
        {
            var result = "Go to https://www.asp.net to see more".AutoLink();
            var expected = @"Go to <a href=""https://www.asp.net"">https://www.asp.net</a> to see more";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_convert_multiple_urls_to_hyperlinks()
        {
            var result = "Go https://www.asp.net to https://www.asp.net".AutoLink();
            var expected = @"Go <a href=""https://www.asp.net"">https://www.asp.net</a> to <a href=""https://www.asp.net"">https://www.asp.net</a>";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_convert_emails_to_hyperlinks()
        {
            var result = "Say to admin@example.com hello".AutoLink();
            var expected = @"Say to <a href=""mailto:admin@example.com"">admin@example.com</a> hello";
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_convert_urls_and_emails()
        {
            var result = "Go to http://www.asp.net and admin@example.com".AutoLink();
            var expected = @"Go to <a href=""http://www.asp.net"">http://www.asp.net</a> and <a href=""mailto:admin@example.com"">admin@example.com</a>";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_use_html_attributes()
        {
            var attributes = new Dictionary<string, string> { {"target", "_blank"}};
            var result = "Go to http://www.asp.net to see more".AutoLink(attributes);
            var expected = @"Go to <a href=""http://www.asp.net"" target=""_blank"">http://www.asp.net</a> to see more";
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_use_custom_textReplacer()
        {
            var result = "Go to http://www.asp.net to see more".AutoLink(textReplacer: x => x.ToUpper());
            var expected = @"Go to <a href=""http://www.asp.net"">HTTP://WWW.ASP.NET</a> to see more";
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AutoLink_should_only_link_emails_when_linkMode_is_email()
        {
            var result = "Go to http://www.asp.net and admin@example.com".AutoLink(linkMode: LinkMode.Email);
            var expected = @"Go to http://www.asp.net and <a href=""mailto:admin@example.com"">admin@example.com</a>";

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void AutoLink_should_only_link_urls_when_linkMode_is_url()
        {
            var result = "Go to http://www.asp.net and admin@example.com".AutoLink(linkMode: LinkMode.Url);
            var expected = @"Go to <a href=""http://www.asp.net"">http://www.asp.net</a> and admin@example.com";

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
