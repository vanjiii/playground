using System;
using System.Text;
/*
 * Write a program that encodes and decodes a string using given encryption key (cipher).
 * The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with        the second, etc.
 * When the last key character is reached, the next is the first.
 */
class EncodeOrdecodeString
{
    static void Main()
    {
        Console.Write("Enter the sting: ");
        string text = Console.ReadLine();
        Console.Write("Ener the crypting key: ");
        string cipher = Console.ReadLine();

        Console.WriteLine("The crypted text is  ->  " + CryptTool(text, cipher));
    }

    private static string CryptTool(string text, string cipher)
    {
        int currentSymbol = new int();
        StringBuilder strBld = new StringBuilder();
        int index = 0;
        int power = 1;
        for (int i = 0; i < text.Length; i++)
        {
            if ((index * 1) == cipher.Length)
            {
                index = 0;
                power++;
            }
            currentSymbol = text[i] ^ cipher[index];
            strBld.Append(currentSymbol);
        }
        return strBld.ToString();
    }
}
