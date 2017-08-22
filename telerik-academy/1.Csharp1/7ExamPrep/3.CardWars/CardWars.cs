using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        checked 
        {
             //Enter how many games (N)
            int numbersGames = int.Parse(Console.ReadLine());

            int numberRounds = 3;
            BigInteger globalScorePlayerOne = 0;
            BigInteger globalScorePlayerTwo = 0;
            bool xCardIsDrawnByPlayerOne = false;
            bool xCardIsDrawnByPlayerTwo = false;
            int countPlaysOne = 0;
            int countPlaysTwo = 0;


            //begin the game - cycle for N games
            for (int i = 0; i < numbersGames; i++)
            {
                int localScorePlayerOne = 0;
                int localScorePlayerTwo = 0;

                // 3 cards of player one
                for (int j = 0; j < numberRounds; j++)
                {
                    string inputPlayerOneCard = Console.ReadLine();
                    switch (inputPlayerOneCard)
                    {
                        case "A": localScorePlayerOne += 1;
                            break;
                        case "J": localScorePlayerOne += 11;
                            break;
                        case "Q": localScorePlayerOne += 12;
                            break;
                        case "K": localScorePlayerOne += 13;
                            break;
                        case "X": xCardIsDrawnByPlayerOne = true;
                            break;
                        case "Y": globalScorePlayerOne -= 200;
                            break;
                        case "Z": globalScorePlayerOne *= 2;
                            break;
                        default: int inputPlayerOneCardInt = int.Parse(inputPlayerOneCard);
                            localScorePlayerOne += 12 - inputPlayerOneCardInt;
                            break;
                    }
                }

                //3 cards of player two
                for (int k = 0; k < numberRounds; k++)
                {
                    string inputPlayerTwoCard = Console.ReadLine();

                    switch (inputPlayerTwoCard)
                    {
                        case "A": localScorePlayerTwo += 1;
                            break;
                        case "J": localScorePlayerTwo += 11;
                            break;
                        case "Q": localScorePlayerTwo += 12;
                            break;
                        case "K": localScorePlayerTwo += 13;
                            break;
                        case "X": xCardIsDrawnByPlayerTwo = true;
                            break;
                        case "Y": globalScorePlayerTwo -= 200;
                            break;
                        case "Z": globalScorePlayerTwo *= 2;
                            break;
                        default: int inputPlayerTwoCardInt = int.Parse(inputPlayerTwoCard);
                            localScorePlayerTwo += 12 - inputPlayerTwoCardInt;
                            break;
                    }
                }

                if (xCardIsDrawnByPlayerOne && xCardIsDrawnByPlayerTwo)
                {
                    
                    globalScorePlayerOne += 50;
                    globalScorePlayerTwo += 50;
                    xCardIsDrawnByPlayerOne = false;
                    xCardIsDrawnByPlayerTwo = false;

                    if (localScorePlayerOne > localScorePlayerTwo)
                    {
                        globalScorePlayerOne += localScorePlayerOne;
                        countPlaysOne++;
                    }
                    else if (localScorePlayerOne < localScorePlayerTwo)
                    {
                        globalScorePlayerTwo += localScorePlayerTwo;
                        countPlaysTwo++;
                    }

                }
                else if (xCardIsDrawnByPlayerOne ^ xCardIsDrawnByPlayerTwo)
                {
                    if (xCardIsDrawnByPlayerOne)
                    {
                        Console.WriteLine("X card drawn! Player one wins the match!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("X card drawn! Player two wins the match!");
                        return;
                    }
                }
                else
                {
                    if (localScorePlayerOne > localScorePlayerTwo)
	                {
		                globalScorePlayerOne += localScorePlayerOne;
                        countPlaysOne++;
	                }
                    else if (localScorePlayerOne < localScorePlayerTwo)
	                {
                        globalScorePlayerTwo += localScorePlayerTwo;
                        countPlaysTwo++;
	                }
                    
                }

            }

            if (globalScorePlayerOne > globalScorePlayerTwo)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", globalScorePlayerOne);
                Console.WriteLine("Games won: {0}", countPlaysOne);
            }
            else if (globalScorePlayerOne < globalScorePlayerTwo)
	        {
		        Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", globalScorePlayerTwo);
                Console.WriteLine("Games won: {0}", countPlaysTwo);
	        }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", globalScorePlayerTwo);
            }
        }
    }
}
