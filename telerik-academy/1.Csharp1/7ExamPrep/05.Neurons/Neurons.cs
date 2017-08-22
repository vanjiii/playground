using System;

class Neurons
{
    static void Main()
    {
        Console.Title = "Neuron mapping";
        

            string stringInput = Console.ReadLine();
            while (stringInput != "-1")
            {

            uint N = uint.Parse(stringInput);


            uint mask;
            bool isOnBoundary = false;
            bool isInNeuron = false;
            bool beenInNeuron = false;

            for (int i = 0; i < 32; i++)
            {
                mask = 1U << i;
                uint checkBit = N & mask;

                if (checkBit != 0)
                {
                    isOnBoundary = true;

                    if (isInNeuron)
                    {
                        isInNeuron = false;
                        beenInNeuron = true;
                    }
                    N &= (~mask);
                }
                else           // is not on boundary; in neuron
                {

                    if (!beenInNeuron && isOnBoundary)
                    {
                        isInNeuron = true;
                        isOnBoundary = false;
                    }

                    if (isInNeuron)
                    {
                        N |= mask;
                    }
                }
            }
            if (!beenInNeuron)
            {
                Console.WriteLine(0);

            }
            else
            {
                Console.WriteLine(N);
                //Console.WriteLine(Convert.ToString(resultNumber, 2).PadLeft(32, '0'));
            }

            stringInput = Console.ReadLine();
        }

        //string binaryDigitsNumber = Convert.ToString(N, 2).PadLeft(32, '0');

    }
}
/*Neuron Mapping
 */