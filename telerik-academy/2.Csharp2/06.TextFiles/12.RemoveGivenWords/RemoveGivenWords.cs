using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
/*
 * Write a program that removes from a text file all words listed in given another text file.
 * Handle all possible exceptions in your methods.
 */
class RemoveGivenWords
{
    static void Main()
    {
        try
        {
            string tempString = string.Empty;
            string patt = string.Empty;
            StringBuilder strBuilder = new StringBuilder();

            using (StreamReader rdr = new StreamReader(@"..\..\Files\pattern.txt"))
            {
                tempString = rdr.ReadLine();
                strBuilder.Append(tempString);
                strBuilder.Append("|");

                while (tempString != null)
                {
                    tempString = rdr.ReadLine();
                    strBuilder.Append(tempString);
                    strBuilder.Append("|");
                }
                int index = strBuilder.Length;
                strBuilder.Remove(index - 2, 2);
            }

            patt = @"\b" + strBuilder.ToString() + @"\b";
            using (StreamReader rdr = new StreamReader(@"..\..\Files\vpn.txt"))
            {
                using (StreamWriter wrt = new StreamWriter(@"..\..\Files\newVpn.txt"))
                {
                    tempString = rdr.ReadLine();

                    while (tempString != null)
                    {
                        wrt.WriteLine(Regex.Replace(tempString, patt, string.Empty));
                        tempString = rdr.ReadLine();
                    }
                }
            }
        }
        catch(FileNotFoundException FNF)
        {
            Console.WriteLine(FNF.Message);
        }
        catch(System.ArgumentException SAE)
        {
            Console.WriteLine(SAE.Message);
        }
        catch(System.UnauthorizedAccessException SUAE)
        {
            Console.WriteLine(SUAE.Message);
        }
        catch(DirectoryNotFoundException DNFE)
        {
            Console.WriteLine(DNFE.Message);
        }
        catch(IOException IOE)
        {
            Console.WriteLine(IOE.Message);
        }
        catch(System.Security.SecurityException SSSE)
        {
            Console.WriteLine(SSSE.Message);
        }
    }
}
