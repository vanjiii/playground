using System;
using System.Text;
    class PrintTheASCIITable
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            for (short i = 0; i < 255; i++)
            {
                char c = (char)i;
                Console.WriteLine("The code of character  " + c + "  is: " + i.ToString());
               
            }
        }
    }
    /*
     Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console.

     */