using System;
using System.IO;
using System.Text;
/*
 * Write a program that deletes from given text file all odd lines. 
 * The result should be in the same file.
 */
class DeleteOddLines
    {
        static void Main()
        {
            Console.WriteLine("Making file...");
            MakeFile(1000);
            Console.WriteLine("File made!");

            string path = @"..\..\Files\bigFile.txt";

            Console.WriteLine("Deleting...");
            DeleteLines(path);
            Console.WriteLine("Lines deleted");
        }

        private static void DeleteLines(string path)
        {
            string tempString = string.Empty;
            int lineCount = new int();
            StringBuilder strBuilder = new StringBuilder();

            using (StreamReader rdr = new StreamReader(path))
            {
                tempString = rdr.ReadLine();
                lineCount++;

                while (tempString != null)
                {
                    tempString = rdr.ReadLine();
                    lineCount++;

                    if (lineCount % 2 == 0)
                    {
                        strBuilder.Append(tempString);
                        strBuilder.Append("\r\n");
                    }
                }
            }

            using (StreamWriter str = new StreamWriter(path))
            {
                tempString = strBuilder.ToString();
                str.WriteLine(tempString);
            }
        }
        private static void MakeFile(int x)
        {
            string line = "this is a very long string";

            StreamWriter str = new StreamWriter(@"..\..\Files\bigFile.txt");
            using (str)
            {
                FileInfo newFile = new FileInfo(@"..\..\Files\bigFile.txt");
                int index = 0;

                while (newFile.Length <= x)
                {
                    str.WriteLine("line {0} : {1}", index + 1, line);
                    index++;
                    newFile.Refresh();
                }
            }
        }
    }