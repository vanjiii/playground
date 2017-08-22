using System;
using System.Collections.Generic;
using System.Threading;

struct Object
{
    public int x;
    public int y;
    public ConsoleColor color;
    public string c;

}
class FallingRocks
{
    static void PrintOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y,string c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void Main()
    {
        
        Console.Title = "Falling Rocks";

        Console.WriteLine(@"This is Falling Rocks!
                            Use Left Arrow and Right Arrow to move
                            your dwarf. You have 3 lives.
                            Please type START to begin with lower cases. ");
        string enterWrod = Console.ReadLine();

        int liveCount = 3;
        int score = 0;

        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 50;

        Object dwarf = new Object();          //The paremeters of our dwarf 
        dwarf.x = 24;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = "(0)";
        dwarf.color = ConsoleColor.Yellow;

        List<Object> otherRocks = new List<Object>();     // list of the falling rocks
        Random randomGemerator = new Random();

        if (enterWrod == "start")
        {
             while (true)
            {
                bool hitted = false;


                int chance = randomGemerator.Next(0, 100);

                //int chance;
                //Random rnd = new Random(DateTime.Now.Millisecond);
                //int[] b = new int[10] { 5, 8, 1, 7, 3, 2, 9, 0, 4, 6 };
                //int[] d = new int[10] { 9, 4, 7, 2, 8, 0, 5, 1, 3, 4 };                                         //random generator
                //int.TryParse(Convert.ToString(b[rnd.Next(10)]) + Convert.ToString(d[rnd.Next(10)]), out chance);

                Object newRock = new Object();
                newRock.x = randomGemerator.Next(0, Console.WindowWidth - 2);
                newRock.y = 0;
                if (chance <= 10)
                {
                    newRock.c = "+";
                    newRock.color = ConsoleColor.Green;
                }
                else if (chance <= 20 && chance > 10)
                {
                    newRock.c = "++";
                    newRock.color = ConsoleColor.Cyan;
                }
                else if (chance >= 30 && chance < 40)
                {
                    newRock.c = "@";
                    newRock.color = ConsoleColor.DarkMagenta;
                }
                else if (chance >= 40 && chance < 50)
                {
                    newRock.c = "=";
                    newRock.color = ConsoleColor.DarkYellow;
                }
                else if (chance >= 50 && chance < 60)
                {
                    newRock.c = "***";
                    newRock.color = ConsoleColor.Gray;
                }
                else if (chance >= 60 && chance < 70)
                {
                    newRock.c = "??";
                    newRock.color = ConsoleColor.White;
                }
                else if (chance >= 70 && chance < 80)
                {
                    newRock.c = "!";
                    newRock.color = ConsoleColor.Yellow;
                }
                else if (chance >= 80 && chance < 90)
                {
                    newRock.c = "<>";
                    newRock.color = ConsoleColor.DarkBlue;
                }
                else 
                {
                    newRock.c = "~";
                    newRock.color = ConsoleColor.DarkGreen;
                }
                otherRocks.Add(newRock);
            
                // fall rocks
                List<Object> newList = new List<Object>();

                for (int i = 0; i < otherRocks.Count; i++)
                {
                    Object oldRocky = otherRocks[i];
                    Object newRocky = new Object();
                    newRocky.x = oldRocky.x;
                    newRocky.y = oldRocky.y + 1;
                    newRocky.c = oldRocky.c;
                    newRocky.color = oldRocky.color;

                    //check if rocks hitting us
                    if (newRocky.y == dwarf.y  )
                    {
                        if ( newRocky.x == dwarf.x + 1 || newRocky.x == dwarf.x + 2 || newRocky.x == dwarf.x )
                        {
                            liveCount--;
                            hitted = true;
                            if (liveCount <= 0)
                            {
                                PrintStringOnPosition(16, 8, "GAME OVER!!!", ConsoleColor.Red);
                                PrintStringOnPosition(16, 10, "Press [enter] to exit", ConsoleColor.Red);
                                PrintStringOnPosition(16, 12, "Your score is: " + score , ConsoleColor.Cyan);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            score++;
                        }
                    }
                
                    if (newRocky.y < Console.WindowHeight)
                    {
                        newList.Add(newRocky);
                    }
                
                
                }
                otherRocks = newList;

                //move our dwarf
                if (Console.KeyAvailable)
                {
                     ConsoleKeyInfo pressedKey = Console.ReadKey(true); // With 'true' we don't print the button we pressed
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);          //'while' to clear the buffer of pressed keys
                                                    // so our dwarf to move more adequate 
                    } 
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.x - 1 >= 0)
                        {
                        dwarf.x--;
                        } 
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.x + 1 <= Console.WindowWidth - 2 )
                        {
                            dwarf.x++;
                        }
                    }
                }
           

        

                //clear console
                Console.Clear();
                
                //Redraw playground
                foreach (Object rocky in otherRocks)
                {
                    PrintOnPosition(rocky.x, rocky.y, rocky.c, rocky.color);
                }

                if (hitted)
                {
                    otherRocks.Clear();
                    PrintOnPosition(dwarf.x, dwarf.y, "X", ConsoleColor.Red);
                    Console.Beep();
                }
                else
                {
                    PrintOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                } 
                //draw info : popup an alert - score, lives

                //slow down program
                Thread.Sleep(150);
            
            }

        }
        else
        {
            Console.WriteLine("Nice try... Next time use start!");
            
        }
    }
}
   

/*
* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash. Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150). Implement collision detection and scoring system.
*/