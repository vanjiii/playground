using System;
/*
 * Write a program that parses an URL address given in the format:

 *      [protocol]://[server]/[resource] 
 
		and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"

 */
class URLadress
{
    static void Main()
    {
        Console.Write("Enter a url: ");
        string url = Console.ReadLine();

        ExtractURLElements(url);
    }

    private static void ExtractURLElements(string url)
    {
        string protocol = string.Empty;
        string server = string.Empty;
        string resource = string.Empty;

        int indexProtocol = url.IndexOf(':', 0);
        protocol = url.Substring(0, indexProtocol);

        int indexEndServer = url.IndexOf('/', protocol.Length + 3);
        int lengthServer = indexEndServer - (protocol.Length + 3);
        server = url.Substring(protocol.Length + 3, lengthServer);

        resource = url.Substring(indexEndServer);

        Console.WriteLine("[protocol] = " + protocol);
        Console.WriteLine("[server] = " + server);
        Console.WriteLine("[resource] = " + resource);
    }
}