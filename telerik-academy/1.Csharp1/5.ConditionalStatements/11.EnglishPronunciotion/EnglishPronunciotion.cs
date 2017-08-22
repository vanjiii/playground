using System;
class EnglishPronunciotion
{
    static void Main()
    {
        Console.Write("Enter a number between 0 and 999: ");
        int a = int.Parse(Console.ReadLine());

        int helpHundred = new int();
        int helpTen = new int();
        int helpDigit = new int();

        string hundred = "";
        string ten = "";
        string digit = "";


        if (a % 10 == 0)
        {
            if (a % 100 == 0)
            {
                if (a % 1000 == 0)
                {
                    Console.WriteLine("Zero");
                }
            }
        }

        if (a % 10 != 0)
        {
            helpDigit = a % 10;
            switch (helpDigit)
            {
                case 1:
                    {
                        digit = "one";
                        break;
                    }
                case 2:
                    {
                        digit = "two";
                        break;
                    }
                case 3:
                    {
                        digit = "three";
                        break;
                    }
                case 4:
                    {
                        digit = "four";
                        break;
                    }
                case 5:
                    {
                        digit = "five";
                        break;
                    }
                case 6:
                    {
                        digit = "six";
                        break;
                    }
                case 7:
                    {
                        digit = "seven";
                        break;
                    }
                case 8:
                    {
                        digit = "eight";
                        break;
                    }
                case 9:
                    {
                        digit = "nine";
                        break;
                    }
                default:
                    break;
            }
        }
        if (a % 100 != 0)
        {
            helpTen = ((a % 100) - helpDigit) / 10;
            if (helpTen == 1)
            {

                switch (helpDigit)
                {

                    case 0:
                        {
                            ten = "and ten";
                            break;
                        }
                    case 1:
                        {
                            ten = "and eleven";
                            break;
                        }
                    case 2:
                        {
                            ten = "and twelve";
                            break;
                        }
                    case 3:
                        {
                            ten = "and thirteen";
                            break;
                        }
                    case 4:
                        {
                            ten = "and fourteen";
                            break;
                        }
                    case 5:
                        {
                            ten = "and fifteen";
                            break;
                        }
                    case 6:
                        {
                            ten = "and sixteen";
                            break;
                        }
                    case 7:
                        {
                            ten = "and seventeen";
                            break;
                        }
                    case 8:
                        {
                            ten = "and eighty";
                            break;
                        }
                    case 9:
                        {
                            ten = "and ninety";
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (helpTen)
                {

                    case 2:
                        {
                            ten = "twenty";
                            break;
                        }
                    case 3:
                        {
                            ten = "thirty";
                            break;
                        }
                    case 4:
                        {
                            ten = "fourty";
                            break;
                        }
                    case 5:
                        {
                            ten = "fifty";
                            break;
                        }
                    case 6:
                        {
                            ten = "sixty";
                            break;
                        }
                    case 7:
                        {
                            ten = "seventy";
                            break;
                        }
                    case 8:
                        {
                            ten = "eighty";
                            break;
                        }
                    case 9:
                        {
                            ten = "ninety";
                            break;
                        }
                    default:
                        break;
                }
            }


        }
        if (a % 1000 != 0)
        {
            helpHundred = ((a % 1000) - (helpTen * 10 + helpDigit)) / 100;
            switch (helpHundred)
            {
                case 1:
                    {
                        hundred = "One hundred";
                        break;
                    }
                case 2:
                    {
                        hundred = "Two hundred";
                        break;
                    }
                case 3:
                    {
                        hundred = "Three hundred";
                        break;
                    }
                case 4:
                    {
                        hundred = "Four hundred";
                        break;
                    }
                case 5:
                    {
                        hundred = "Five hundred";
                        break;
                    }
                case 6:
                    {
                        hundred = "Six hundred";
                        break;
                    }
                case 7:
                    {
                        hundred = "Seven hundred";
                        break;
                    }
                case 8:
                    {
                        hundred = "Eight hundred";
                        break;
                    }
                case 9:
                    {
                        hundred = "Nine hundred";
                        break;
                    }
                default:
                    break;
            }
        }

        if (ten == "" && hundred != "" && digit != "")
        {
            Console.WriteLine(hundred + " and " + digit);
        }
        else if (helpTen == 1)
        {
             Console.WriteLine(hundred + " " + ten);
        }
        else
        {
            Console.WriteLine(hundred + " " + ten + " " + digit);
        }


    }
}
/*
* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
0  "Zero"
273  "Two hundred seventy three"
400  "Four hundred"
501  "Five hundred and one"
711  "Seven hundred and eleven"

*/