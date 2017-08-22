using System;
using System.IO;
using System.Text.RegularExpressions;
/*
 * Write a program that deletes from a text file all words that start with the prefix "test".
 * Words contain only the symbols 0...9, a...z, A…Z, _.
 */
class DeleteSpesificWord
{
    static void Main()
    {
        //The text is saved to another file so u can see the result =)

        string tempString = string.Empty;
        string pattern = @"\btest\w*\b";

        using (StreamReader rdr = new StreamReader(@"..\..\Files\regExpression.txt"))
        {
            using (StreamWriter wrt = new StreamWriter(@"..\..\Files\regExpressionOut.txt"))
            {
                tempString = rdr.ReadLine();

                while (tempString != null)
                {
                    wrt.WriteLine(Regex.Replace(tempString, pattern, string.Empty));
                    tempString = rdr.ReadLine();
                }
            }
        }
    }
}