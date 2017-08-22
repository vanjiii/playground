using System;
using System.IO;
/*
 * Write a program that reads a text file and inserts line numbers in front of each of its lines.
 * The result should be written to another text file.
 */
class InsertLines
{
    static void Main()
    {
        StreamReader fileToRead = new StreamReader(@"..\..\Files\alph.txt");
        StreamWriter fileToWrite = new StreamWriter(@"..\..\Files\newText.txt");

        using (fileToRead)
        {
            using (fileToWrite)
            {
                string text = fileToRead.ReadLine();
                int i = 48;

                while (text != null)
                {
                    fileToWrite.WriteLine(new string((char)i, 5));
                    fileToWrite.WriteLine(text);
                    text = fileToRead.ReadLine();
                    i++;
                }
            }
        }
        Console.WriteLine("Process done!");
    }
}