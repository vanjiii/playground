using System;
using System.IO;

/*
 * Write a program that reads a text file and prints on the console its odd lines.
 */
class PrintOddLinesOfFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\Files\testFile.txt");

        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 == 1)
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                }
                
                line = reader.ReadLine();
            }
        }
    }
}