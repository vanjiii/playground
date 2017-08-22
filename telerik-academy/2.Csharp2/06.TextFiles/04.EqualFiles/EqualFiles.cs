using System;
using System.IO;
/*
 * Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
 * Assume the files have equal number of lines.
 */
class EqualFiles
{
    static void Main()
    {
        StreamReader file1 = new StreamReader(@"..\..\Files\alph.txt");
        StreamReader file2 = new StreamReader(@"..\..\Files\newText.txt");
        int equalLines = 0;
        int diffLines = 0;

        using (file1)
        {
            using (file2)
            {
                string textToCompare = file1.ReadLine();
                string secondText = file2.ReadLine();

                while (textToCompare != null)
                {
                    if (textToCompare == secondText)
                    {
                        equalLines++;
                    }
                    else
                    {
                        diffLines++;
                    }

                    textToCompare = file1.ReadLine();
                    secondText = file2.ReadLine();
                }
            }
        }
        Console.WriteLine("Equal lines - {0}, and different are - {1}.", equalLines, diffLines);
    }
}