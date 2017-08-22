using System;
/*
 * Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
 * Sample HTML fragment:
 
        <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

        <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

 */
class RelpaceTagsInHTML
{
    static void Main()
    {
        Console.Write("Enter a html: ");
        string html = Console.ReadLine();

        ReplaceHTMLTags(html);
    }

    private static void ReplaceHTMLTags(string html)
    {
        int startARef = html.IndexOf("<a href", 0);
        html = html.Replace("<a href=\"", "[URL=");
        html = html.Replace("\" > \"", "]");
        html = html.Replace("</a>", "[/URL]");

        Console.WriteLine(new string('-', 10) + "Result" + new string('-', 10));
        Console.WriteLine(html);
    }
}