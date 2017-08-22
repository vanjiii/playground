using System;


class NineGagNumbers
{
    static string Numbers(string str)
    {
        switch (str)
        {
            case "-!": return "0";
            case "**": return "1";
            case "!!!": return "2";
            case "&&": return "3";
            case "&-": return "4";
            case "!-": return "5";
            case "*!!!": return "6";
            case "&*!": return "7";
            case "!!**!-": return "8";
        }
        return "";
    }
    static decimal Pow(int x, int y)
    {
        decimal num = 1;
        for (int i = 0; i < y; i++)
        {
            num = num * 9;
        }
        return num;
    }


    static void Main()
    {
        string str = Console.ReadLine();
        string num = string.Empty;
        int subs = 0;
        int pow = 0;
        decimal sum = 0;
        // BigInteger sum = 0;
        string met;
        for (int i = 0; i < str.Length && i != str.Length - subs + 1 && subs != str.Length; i++)
        {
            met = Numbers(str.Substring(subs, i + 1));
            if (met != "")
            {
                num += met;
                subs += i + 1;
                i = 0;
            }
        }
        //Console.WriteLine(num);

        for (int j = num.Length - 1; j >= 0; j--)
        {
            sum += Convert.ToDecimal(num.Substring(j, 1)) * Pow(9, pow);
            pow++;
        }
        Console.WriteLine("{0}", sum);
    }
}