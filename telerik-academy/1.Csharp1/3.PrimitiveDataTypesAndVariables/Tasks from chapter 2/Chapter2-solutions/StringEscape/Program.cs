using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringEscape
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            string sixSpaces = "      ";
            string nO = new string('O', N);
            for (int i = 0; i < 3; i++)
            {

                Console.Write(sixSpaces);
                Console.Write(nO);
                Console.Write(sixSpaces);
                Console.Write(sixSpaces);
                Console.WriteLine(nO);
                sixSpaces=sixSpaces.Remove(sixSpaces.Length - 2, 2);
                nO += "OOOO";
            }

            nO += nO;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(nO);
            }

            
                while(nO.Length>4)
            {
                nO = nO.Remove(nO.Length - 4, 4);
                sixSpaces += "  ";
                Console.Write(sixSpaces);
                Console.WriteLine(nO);
            }
        }
    }
}
