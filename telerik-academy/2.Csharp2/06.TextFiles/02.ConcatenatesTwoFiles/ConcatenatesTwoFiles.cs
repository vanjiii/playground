using System;
using System.IO;

/*
 * Write a program that concatenates two text files into another text file.
 */
class ConcatenatesTwoFiles
{
    static void Main()
    {
        StreamReader file1Reader = new StreamReader(@"..\..\Files\alph.txt");
        StreamReader file2Reader = new StreamReader(@"..\..\Files\decimal.txt");
        StreamWriter streamWriter = new StreamWriter(@"..\..\Files\Created-File.txt");

        using (streamWriter)
        {
            using (file1Reader)
            {
                string file1 = file1Reader.ReadLine();

                while (file1 != null)
                {
                    streamWriter.WriteLine(file1);
                    file1 = file1Reader.ReadLine();
                }

            }
            using (file2Reader)
            {
                string file2 = file2Reader.ReadLine();

                while (file2 != null)
                {
                    streamWriter.WriteLine(file2);
                    file2 = file2Reader.ReadLine();
                }
            }
        }
        Console.WriteLine("Copying done!");
    }
}
