using System;
    class NfacKfacExten
    {
        static void Main()
        {
            Console.Title = "N!*K! / (K-N) , (1<N<K) ";

            Console.WriteLine("(1<N<K)");
            int k, n, sum = 1;
            do
            {
                Console.Write("Enter K: ");
                k = int.Parse(Console.ReadLine());
                Console.Write("Enter N : ");
                n = int.Parse(Console.ReadLine());
            } while (1 < k && k < n);

            for (int i = (k - n + 1); i <= k; i++)
            {
                sum *= i;
            }
            for (int j = 1; j <= n; j++)
            {
                sum *= j;
            }
            Console.WriteLine(sum);
        }
    }
/*
Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

*/


/* 
* [k! / k(-n)!] * n!
*  n = 3!; k = 10! => (1*2*3*   1*2*3*4*5*6*7*8*9*10)/ (1*2*3*4*5*6*7) = 1*2*3  *8*9*10
* */