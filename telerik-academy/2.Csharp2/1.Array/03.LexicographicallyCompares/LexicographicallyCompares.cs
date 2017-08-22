using System;
using System.Linq;
/*
 * Write a program that compares two char arrays lexicographically (letter by letter).
 */
class LexicographicallyCompares
{
    static void Main()
    {
        //comparing two char arrays is literally is comparing two strings.
        //but we are not going to handle the problem that way

        //initializing the string arrays
        string[] a = { "The", "Big", "Ant" };
        string[] b = { "Big", "Ant", "Ran" };
        string[] c = { "The", "Big", "Ant" };
        string[] d = { "No", "Ants", "Here" };
        string[] e = { "The", "Big", "Ant", "Ran", "Too", "Far" };

        //make the comparison
        bool areEqualab = a.SequenceEqual(b);
        bool areEqualac = a.SequenceEqual(c);
        bool areEqualad = a.SequenceEqual(d);
        bool areEqualae = a.SequenceEqual(e);
        bool areEqualbc = b.SequenceEqual(c);
        bool areEqualbd = b.SequenceEqual(d);
        bool areEqualbe = b.SequenceEqual(e);
        bool areEqualcd = c.SequenceEqual(d);
        bool areEqualce = c.SequenceEqual(e);
        bool areEqualde = a.SequenceEqual(e);

        Console.WriteLine("A and B {0} equal", areEqualab ? "are" : "are not");
        Console.WriteLine("A and C {0} equal", areEqualac ? "are" : "are not");
        Console.WriteLine("A and D {0} equal", areEqualad ? "are" : "are not");
        Console.WriteLine("A and E {0} equal", areEqualae ? "are" : "are not");
        Console.WriteLine("B and C {0} equal", areEqualbc ? "are" : "are not");
        Console.WriteLine("B and D {0} equal", areEqualbd ? "are" : "are not");
        Console.WriteLine("B and E {0} equal", areEqualbe ? "are" : "are not");
        Console.WriteLine("C and D {0} equal", areEqualcd ? "are" : "are not");
        Console.WriteLine("C and D {0} equal", areEqualce ? "are" : "are not");
        Console.WriteLine("D and E {0} equal", areEqualde ? "are" : "are not");

    }
}
