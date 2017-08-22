using System;
/*
 * You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.

 * The expected result:
We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

 */
class UppercaseInTags
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();

        Console.WriteLine("The new text is:  " + UpLettersBetweenTags(text));
    }

    private static string UpLettersBetweenTags(string text)
    {
        int startIndex = text.IndexOf("<upcase>", 0);
        int endIndex = text.IndexOf("</upcase>", 0);
        string subStr = string.Empty;

        while (startIndex != -1)
        {
            subStr = text.Substring(startIndex + 8, endIndex - (startIndex + 8));
            text = text.Replace(subStr, subStr.ToUpper());
            startIndex = text.IndexOf("<upcase>", startIndex + 1);
            endIndex = text.IndexOf("</upcase>", endIndex + 1);
        }

        text = text.Replace("<upcase>", "");
        text = text.Replace("</upcase>", "");
        return text;
    }
}