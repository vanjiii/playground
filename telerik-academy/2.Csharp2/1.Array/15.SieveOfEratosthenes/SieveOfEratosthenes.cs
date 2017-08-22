using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        int N = 10000000;
        string[] primeArray = new string[N];
        int p = 0;

        //fill the array
        for (int i = 2; i < N; i++)
        {
            primeArray[i] = "yes";
        }

        int max = (int)Math.Sqrt(N);

        for (int j = 2; j < max; j++)
        {
            if (primeArray[j] == "yes")
            {
                p = j;

                for (int ii = p * p; ii < primeArray.Length; ii += j)
                {
                        primeArray[ii] = "no";
                }
            }
        }

        for (int i = 0; i < primeArray.Length; i++)
        {
            if (primeArray[i] == "yes")
            {
                Console.Write(i + " ");
            }

        }
    }
}



//using System;

//class Program
//{
//    static void Main()
//    {
//        bool[] arr = new bool[(int)1E7 + 1];

//        for (int i = 2; i * i <= arr.Length; i++)
//            if (!arr[i])
//                for (int j = i * i; j < arr.Length; j += i) arr[j] = true;

//        for (int i = 2; i < arr.Length; i++) if (!arr[i]) Console.WriteLine(i);
//    }
//}
