using System;
class NfacDividedKfac
{
    static void Main()
    {
        Console.Title = "N!/k!, (1<K<N)";

        Console.WriteLine("(1<K<N)");
        int k, n, sum = 1;
        do
        {
            Console.Write("Enter K: ");
            k = int.Parse(Console.ReadLine());
            Console.Write("Enter N : ");
            n = int.Parse(Console.ReadLine());
        } while (1 > k && k > n);

        for (int i = (k + 1); i <= n ; i++)
        {
            sum *= i;
        }
        Console.WriteLine(sum);
    }
}
/*
* Write a program that calculates N!/K! for given N and K (1<K<N).
*/

/*
 hint: 5!/3! = 1*2*3*4*5 / 1*2*3 = 4*5 = 20
 */