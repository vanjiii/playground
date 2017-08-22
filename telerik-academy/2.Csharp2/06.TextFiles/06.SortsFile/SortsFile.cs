using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
/*
 * Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
	Ivan			George
	Peter			Ivan
	Maria	->		Maria
	George			Peter

 */
class SortsFile
{
    static void Main()
    {
        StreamReader names = new StreamReader(@"..\..\Files\names.txt");
        List<string> tempString = new List<string>();

        using (names)
        {
            string line = names.ReadLine();
            while (line != null)
            {
                tempString.Add(line);
                line = names.ReadLine();
            }
            
        }
        int size = tempString.Count;
        tempString.Sort();
        

        StreamWriter file = new StreamWriter(@"..\..\Files\sortArray.txt");
        using (file)
        {
            foreach (var item in tempString)
            {
                file.WriteLine(item);
            }
        }
    }
}