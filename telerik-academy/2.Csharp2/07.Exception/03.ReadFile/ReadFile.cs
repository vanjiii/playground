using System;
using System.IO;
/*
 * Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
 * Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
 */
class ReadFile
{
    static void Main()
    {
        try
        {
            Console.Write("Enter file: ");
            string pathToFile = Console.ReadLine();
            string tempString = File.ReadAllText(pathToFile);
            Console.WriteLine("--- Contents of the file: ---");
            Console.WriteLine(tempString);
        }
        catch(System.IO.FileNotFoundException) 
        {
            throw new Exception("The file is not found; check the name again =)");
        }
        catch(System.UnauthorizedAccessException)
        {
            throw new Exception ("This file is protected with administrative rights; please, be sure u are administrator. ");
        }
        catch(DirectoryNotFoundException)
        {
            throw new Exception("The file is not found; check the path again. ");
        }
        catch(System.ArgumentNullException)
        {
            throw new Exception("The file is empty! ");
        }
        catch(System.IO.PathTooLongException)
        {
            throw new Exception("The path is too long to handle! ");
        }
    }
}