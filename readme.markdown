The TextHelper library provides a set of methods for filtering, formatting and transforming strings, which can reduce the amount of inline C# code in your views. These helper methods extend System.String making usable within existing code bases.

Inspired by the [Ruby on Rails Text Helpers](http://api.rubyonrails.org/classes/ActionView/Helpers/TextHelper.html#method-i-truncate)

## AutoLink
Turns all URLs and e-mail addresses into clickable links.

	"Go to http://www.asp.net and admin@example.com".AutoLink();
	// => @"Go to <a href=""http://www.asp.net"">http://www.asp.net</a> and <a href=""mailto:admin@example.com"">admin@example.com</a>";

	"Go to http://www.asp.net to see more".AutoLink(textReplacer: x => x.ToUpper());
	// => @"Go to <a href=""http://www.asp.net"">HTTP://WWW.ASP.NET</a> to see more";

	"Go to http://www.asp.net and admin@example.com".AutoLink(linkMode: LinkMode.Email);
	// => @"Go to http://www.asp.net and <a href=""mailto:admin@example.com"">admin@example.com</a>";

	"Go to http://www.asp.net to see more".AutoLink(new Dictionary<string, string> { {"target", "_blank"}});
	// => @"Go to <a href=""http://www.asp.net"" target=""_blank"">http://www.asp.net</a> to see more";

## Excerpt
Extracts an excerpt from text that matches the first instance of phrase. The resulting string will be stripped in any case.

	"hello world".Excerpt(" ", 2);
	// =>"...lo wo..."

	"hello world".Excerpt(" ", 2, "<cut>");
	// => "<cut>lo wo<cut>";

## Highlight
Highlights one or more phrases everywhere in text by inserting it into a highlighter string.

	"hello world".Highlight("world");
	// => @"hello <strong class=""highlighted"">world</strong>";

	"hello world".Highlight("world", "<b>{0}</b>");
	// => @"hello <b>world</b>";

	"hello world".Highlight(new List<string> {"Hello", "World"}, "[{0}]");
	// => @"[hello] [world]";

## Pluraize
Attempts to pluralize the singular word unless count is 1.

	"apple".Pluralize(2);
	// => "apples";

	"octpus".Pluralize(1, "octopi");
	// => "octpus";

	"octpus".Pluralize(2, "octopi");
	// => "octopi";

## SimpleFormat
Returns text transformed into HTML using simple formatting rules. Two or more consecutive newlines(\n\n) are considered as a paragraph and wrapped in <p> tags. One newline (\n) is considered as a linebreak and a <br/> tag is appended. This method does not remove the newlines from the text.## Truncate

	"hello\n world".ToSimpleFormat();
	// => "<p>hello\n<br/> world</p>";

	"hello\n\n world".ToSimpleFormat();
	// => "<p>hello</p>\n\n<p> world</p>";

## Truncate
Truncates a given text after a given length.

	"hello".Truncate(4);
	// => "hell..."

	"hello world".Truncate(8, separator: " ");
	// => "hello...";

	"hello world".Truncate(8, "<end>", " ");
	// => "hello<end>";

## WordWrap
Wraps the text into lines at the word boundary nearest to the lineWidth.

	"hello world \nhere I come\nagain".WordWrap(7);
	// => "hello\nworld\nhere I\ncome\nagain";