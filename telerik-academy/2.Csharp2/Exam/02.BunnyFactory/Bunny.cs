using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
class Bunny
{
    static void Main()
    {
        string input = Console.ReadLine(); ;
        List<string> bunnies = new List<string>();
        while (input != "END")
        {
            bunnies.Add(input);
            input = Console.ReadLine();
        }
        StringBuilder result = MultBunnies(bunnies);

        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
        //Console.WriteLine();
    }

    /* private static StringBuilder MultBunnies(List<string> bunnies)
     {
         //first cycle
         int s = new int();
         StringBuilder newBunnies = new StringBuilder();
         StringBuilder tempBunny = new StringBuilder();
         int sum = new int();
         BigInteger product = 1;
         int cycle = int.Parse(bunnies[0]);

         for (int i = 1; i <= cycle; i++)
         {
             sum += int.Parse(bunnies[i]);
             product *= int.Parse(bunnies[i]);
         }

         //append rest
         newBunnies.Append(sum);
         newBunnies.Append(product);
         sum = 0;
         product = 1;

         for (int i = 4; i < bunnies.Count; i++)
         {
             newBunnies.Append(BigInteger.Parse(bunnies[i]));
         }

         //clear 1,0
         for (int i = 0; i < newBunnies.Length; i++)
         {
             if (newBunnies[i] == '1')
             {
                 newBunnies.Remove(i, 1);
             }
             if (newBunnies[i] == '0')
             {
                 newBunnies.Remove(i, 1);
             }
         }
         //rest

         do
         {
             cycle = int.Parse(newBunnies[0].ToString());

             for (int i = 0; i < cycle; i++)
             {
                 s += int.Parse(newBunnies[i].ToString());
             }
             if (s > newBunnies.Length)
             {
                 break;
             }
             for (int i = (int)cycle; i < s + (int)cycle; i++)
             {
                 sum += int.Parse(newBunnies[i].ToString());
                 product *= int.Parse(newBunnies[i].ToString());
             }
            

             tempBunny = newBunnies;
             newBunnies = new StringBuilder();
             newBunnies.Append(sum);
             newBunnies.Append(product);
             for (int j = s + (int)cycle; j < tempBunny.Length; j++)
             {
                 newBunnies.Append(tempBunny[j]);
             }

             //clear 1,0
             for (int i = 0; i < newBunnies.Length; i++)
             {
                 if (newBunnies[i] == '1')
                 {
                     newBunnies.Remove(i, 1);
                 }
                 if (newBunnies[i] == '0')
                 {
                     newBunnies.Remove(i, 1);
                 }
             }
             s = 0;
         } while (true) ;
         return newBunnies;

     }
     */
    private static StringBuilder MultBunnies(List<string> bunnies)
    {
        int cycle = 1;
        int s = 1;
        StringBuilder newBunnies = new StringBuilder();
        StringBuilder tempBunny = new StringBuilder();
        int sum = new int();
        BigInteger product = 1;
        foreach (var item in bunnies)
        {
            newBunnies.Append(item);
        }
        do
        {
            if (cycle == 1)
            {
                cycle = int.Parse(newBunnies[0].ToString());
                if (cycle > newBunnies.Length - 1)
                {
                    break;
                }
                for (int i = 1; i <= cycle; i++)
                {
                    sum += int.Parse(bunnies[i]);
                    product *= int.Parse(bunnies[i]);
                }

                //append resttempBunny = newBunnies;

                tempBunny = newBunnies;
                newBunnies = new StringBuilder();
                newBunnies.Append(sum);
                newBunnies.Append(product);
                for (int j = s + (int)cycle; j < tempBunny.Length; j++)
                {
                    newBunnies.Append(tempBunny[j]);
                }
                sum = 0;
                product = 1;

                //clear 1,0
                for (int i = 0; i < newBunnies.Length; i++)
                {
                    if (newBunnies[i] == '1')
                    {
                        newBunnies.Remove(i, 1);
                    }
                    if (newBunnies[i] == '0')
                    {
                        newBunnies.Remove(i, 1);
                    }
                }
                cycle = 1;
                s = 0;
            }
            else
            {
                //rest
                for (int i = 0; i < cycle; i++)
                {
                    s += int.Parse(newBunnies[i].ToString());
                }

                //add cycle
                if (s > newBunnies.Length)
                {
                    break;
                }
                if (s + cycle > newBunnies.Length)
                {
                    break;
                }

                for (int i = (int)cycle; i < s + (int)cycle; i++)
                {
                    sum += int.Parse(newBunnies[i].ToString());
                    product *= int.Parse(newBunnies[i].ToString());
                }

                tempBunny = newBunnies;
                newBunnies = new StringBuilder();
                newBunnies.Append(sum);
                newBunnies.Append(product);
                sum = 0;
                product = 1;
                for (int j = s + (int)cycle; j < tempBunny.Length; j++)
                {
                    newBunnies.Append(tempBunny[j]);
                }

                //clear 1,0
                for (int i = 0; i < newBunnies.Length; i++)
                {
                    if (newBunnies[i] == '1')
                    {
                        newBunnies.Remove(i, 1);
                    }
                    if (newBunnies[i] == '0')
                    {
                        newBunnies.Remove(i, 1);
                    }
                }
                s = 0;
            }
            cycle++;
        } while (cycle < newBunnies.Length);
        return newBunnies;
    }
}