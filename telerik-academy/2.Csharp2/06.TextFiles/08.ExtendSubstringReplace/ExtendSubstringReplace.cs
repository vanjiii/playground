using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/*
 * Modify the solution of the previous problem to replace only whole words (not substrings).
 */
class ExtendSubstringReplace
    {
        const int MaxSizeOfFile = 101000000;
        static void Main()
        {
            Console.WriteLine("creating...");
            MakeFile(MaxSizeOfFile);
            Console.WriteLine("File created.");

            string strToSearch = "start";
            string strToReplace = "finish";
            string path = @"..\..\Files\bigFile.txt";

            Console.WriteLine("replacing");
            ReplaceString(strToSearch, strToReplace, path);
            Console.WriteLine("Replace finished.");
        }

        private static void ReplaceString(string strToSearch, string strToReplace, string path)
        {
            string tempString = string.Empty;
            StringBuilder strBuilder = new StringBuilder();
            using (StreamReader rdr = new StreamReader(path))
            {
                //reading file
                tempString = rdr.ReadToEnd();
                //int count = 1024;
                //char[] buffer = new char[count];
                //while (tempString != null)
                //{
                //    strBuilder.Append(tempString = rdr.Read(buffer,0,1024).ToString());
                //}

                //tempString = strBuilder.ToString();

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
            string line = "Thisfileisfullofstartsandfinishies,replaceallthestart,ifucan;start";

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
