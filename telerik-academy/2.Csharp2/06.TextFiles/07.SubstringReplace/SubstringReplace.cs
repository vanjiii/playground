using System;
using System.IO;
/*
 * Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

 */
class SubstringReplace
    {
    const int MaxSizeOfFile = 101000000;
        static void Main()
        {
            MakeFile(MaxSizeOfFile);
            Console.WriteLine("File created.");

            string strToSearch = "start";
            string strToReplace = "finish";
            string path = @"..\..\Files\bigFile.txt";

            ReplaceString(strToSearch, strToReplace, path);
            Console.WriteLine("Replace finished.");
        }

        private static void ReplaceString(string strToSearch, string strToReplace, string path)
        {
            string tempString = string.Empty;
            using(StreamReader rdr = new StreamReader(path))
	        {
                tempString = rdr.ReadToEnd();

                int index = tempString.IndexOf(strToSearch, 0);

                while (index != -1)
                {
                    tempString = tempString.Replace(strToSearch, strToReplace);
                    index = tempString.IndexOf(strToSearch, index + 1);
                }
	        }
            using (StreamWriter str = new StreamWriter(path))
            {
                str.WriteLine(tempString);
            }
        }

        private static void MakeFile(int x)
        {
            string line = "This file is full of starts and finishies, replace all the start, if u can; start";

            StreamWriter str = new StreamWriter(@"..\..\Files\bigFile.txt");
            using (str)
            {
                FileInfo newFile = new FileInfo(@"..\..\Files\bigFile.txt");

                while (newFile.Length <= x)
                {
                    str.WriteLine(line);
                    newFile.Refresh();
                }
            }
        }
    }
