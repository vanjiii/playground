using System;
using System.Net;
/*
 * Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory.
 * Find in Google how to download files in C#.
 * Be sure to catch all exceptions and to free any used resources in the finally block.

 */
class DownloadFileFromTheNet
{
    static void Main()
    {
        try
        {
            Console.Write("Enter URL: ");
            string url = Console.ReadLine();
            Console.Write("Where do u want to save the file: ");
            string home = Console.ReadLine();
            WebClient wbc = new WebClient();
            wbc.DownloadFile(url, home);
        }
        catch(System.ArgumentNullException)
        {
            throw new Exception("This is not valid url");
        }
        catch(System.Net.WebException)
        {
            throw new Exception("Check your net connection!!!");
        }
    }
}
