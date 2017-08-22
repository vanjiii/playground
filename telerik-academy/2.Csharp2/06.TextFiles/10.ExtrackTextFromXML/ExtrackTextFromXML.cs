using System;
using System.IO;
/*
 * Write a program that extracts from given XML file all the text without the tags. 
 * Example:
 *  
<?xml version="1.0"?>
<student>
    <name>Pesho</name>
    <age>21</age>
    <interests count="3">
        <interest>Games</interest>
        <interest>C#</interest>
        <interest>Java</interest>
    </interests>
</student>
 */
class ExtrackTextFromXML
{
    static void Main()
    {
        char tempString = new char();
        int boundary = new int();
        string text = string.Empty;

        using (StreamReader rdr = new StreamReader(@"..\..\Files\someFile.xml"))
        {
             boundary = rdr.Read();
            while ('~' - tempString > 0)
            {
                if (tempString == '>')
                {
                    tempString = (char)rdr.Read();
                    while ((tempString != '<') && ('~' - tempString > 0))
                    {
                        if (tempString != '\n' && tempString != '\r' )
                        {
                            text += (char)tempString;
                            tempString = (char)rdr.Read();
                        }
                        else
                        {
                            tempString = (char)rdr.Read();
                        }
                    }
                    Console.WriteLine(text.Trim());
                    text = string.Empty;
                }
                boundary = rdr.Read();
                tempString = (char)boundary;
            }   
        }
    }
}
