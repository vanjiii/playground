using System;

class Cards
{
    static void Main()
    {
        Console.Title = "Cards";

        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                switch (Convert.ToString(i) + Convert.ToString(j))
                {
                    case "11":
                        {
                            Console.WriteLine("Ace, Clubs");
                            break;
                        }
                    case "12":
                        {
                            Console.WriteLine("2, Clubs");
                            break;
                        }
                    case "13":
                        {
                            Console.WriteLine("3, Clubs");
                            break;
                        }
                    case "14":
                        {
                            Console.WriteLine("4, Clubs");
                            break;
                        }
                    case "15":
                        {
                            Console.WriteLine("5, Clubs");
                            break;
                        }
                    case "16":
                        {
                            Console.WriteLine("6, Clubs");
                            break;
                        }
                    case "17":
                        {
                            Console.WriteLine("7, Clubs");
                            break;
                        }
                    case "18":
                        {
                            Console.WriteLine("8, Clubs");
                            break;
                        }
                    case "19":
                        {
                            Console.WriteLine("9, Clubs");
                            break;
                        }
                    case "110":
                        {
                            Console.WriteLine("10, Clubs");
                            break;
                        }
                    case "111":
                        {
                            Console.WriteLine("Jack, Clubs");
                            break;
                        }
                    case "112":
                        {
                            Console.WriteLine("Queen, Clubs");
                            break;
                        }
                    case "113":
                        {
                            Console.WriteLine("King, Clubs");
                            break;
                        }
                    case "21":
                        {
                            Console.WriteLine("Ace, Diamonds");
                            break;
                        }
                    case "22":
                        {
                            Console.WriteLine("2, Diamonds");
                            break;
                        }
                    case "23":
                        {
                            Console.WriteLine("3, Diamonds");
                            break;
                        }
                    case "24":
                        {
                            Console.WriteLine("4, Diamonds");
                            break;
                        }
                    case "25":
                        {
                            Console.WriteLine("5, Diamonds");
                            break;
                        }
                    case "26":
                        {
                            Console.WriteLine("6, Diamonds");
                            break;
                        }
                    case "27":
                        {
                            Console.WriteLine("7, Diamonds");
                            break;
                        }
                    case "28":
                        {
                            Console.WriteLine("8, Diamonds");
                            break;
                        }
                    case "29":
                        {
                            Console.WriteLine("9, Diamonds");
                            break;
                        }
                    case "210":
                        {
                            Console.WriteLine("10, Diamonds");
                            break;
                        }
                    case "211":
                        {
                            Console.WriteLine("Jack, Diamonds");
                            break;
                        }
                    case "212":
                        {
                            Console.WriteLine("Queen, Diamonds");
                            break;
                        }
                    case "213":
                        {
                            Console.WriteLine("King, Diamonds");
                            break;
                        }
                    case "31":
                        {
                            Console.WriteLine("Ace, Hearts");
                            break;
                        }
                    case "32":
                        {
                            Console.WriteLine("2, Hearts");
                            break;
                        }
                    case "33":
                        {
                            Console.WriteLine("3, Hearts");
                            break;
                        }
                    case "34":
                        {
                            Console.WriteLine("4, Hearts");
                            break;
                        }
                    case "35":
                        {
                            Console.WriteLine("5, Hearts");
                            break;
                        }
                    case "36":
                        {
                            Console.WriteLine("6, Hearts");
                            break;
                        }
                    case "37":
                        {
                            Console.WriteLine("7, Hearts");
                            break;
                        }
                    case "38":
                        {
                            Console.WriteLine("8, Hearts");
                            break;
                        }
                    case "39":
                        {
                            Console.WriteLine("9, Hearts");
                            break;
                        }
                    case "310":
                        {
                            Console.WriteLine("10, Hearts");
                            break;
                        }
                    case "311":
                        {
                            Console.WriteLine("Jack, Hearts");
                            break;
                        }
                    case "312":
                        {
                            Console.WriteLine("Queen, Hearts");
                            break;
                        }
                    case "313":
                        {
                            Console.WriteLine("King, Hearts");
                            break;
                        }
                    case "41":
                        {
                            Console.WriteLine("Ace, Spades");
                            break;
                        }
                    case "42":
                        {
                            Console.WriteLine("2, Clubs");
                            break;
                        }
                    case "43":
                        {
                            Console.WriteLine("3, Spades");
                            break;
                        }
                    case "44":
                        {
                            Console.WriteLine("4, Spades");
                            break;
                        }
                    case "45":
                        {
                            Console.WriteLine("5, Spades");
                            break;
                        }
                    case "46":
                        {
                            Console.WriteLine("6, Spades");
                            break;
                        }
                    case "47":
                        {
                            Console.WriteLine("7, Spades");
                            break;
                        }
                    case "48":
                        {
                            Console.WriteLine("8, Spades");
                            break;
                        }
                    case "49":
                        {
                            Console.WriteLine("9, Spades");
                            break;
                        }
                    case "410":
                        {
                            Console.WriteLine("10, Spades");
                            break;
                        }
                    case "411":
                        {
                            Console.WriteLine("Jack, Spades");
                            break;
                        }
                    case "412":
                        {
                            Console.WriteLine("Queen, Spades");
                            break;
                        }
                    case "413":
                        {
                            Console.WriteLine("King, Spades");
                            break;
                        }

                    default:
                        break;  
                }
            }
            Console.WriteLine();
        }
    }
}

/*
Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.
*/