using System;
using System.Text;

class FallDown
{
    static void Main()
    {

        // The input
        int n0 = int.Parse(Console.ReadLine());
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int n4 = int.Parse(Console.ReadLine());
        int n5 = int.Parse(Console.ReadLine());
        int n6 = int.Parse(Console.ReadLine());
        int n7 = int.Parse(Console.ReadLine());

        //Logic


        for (int ii = 0; ii < 7; ii++)          //in the worst case one box is going to fall 7 times to reach the row n7
        {

            //move over every bit of the n7
            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n7 >> bitPosition & 1) == 0 &&
                    (n6 >> bitPosition & 1) == 1)
                {
                    n7 |= 1 << bitPosition;         //make the current bit 1
                    n6 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n6 >> bitPosition & 1) == 0 &&
                    (n5 >> bitPosition & 1) == 1)
                {
                    n6 |= 1 << bitPosition;         //make the current bit 1
                    n5 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n5 >> bitPosition & 1) == 0 &&
                    (n4 >> bitPosition & 1) == 1)
                {
                    n5 |= 1 << bitPosition;         //make the current bit 1
                    n4 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n4 >> bitPosition & 1) == 0 &&
                    (n3 >> bitPosition & 1) == 1)
                {
                    n4 |= 1 << bitPosition;         //make the current bit 1
                    n3 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n3 >> bitPosition & 1) == 0 &&
                    (n2 >> bitPosition & 1) == 1)
                {
                    n3 |= 1 << bitPosition;         //make the current bit 1
                    n2 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n2 >> bitPosition & 1) == 0 &&
                    (n1 >> bitPosition & 1) == 1)
                {
                    n2 |= 1 << bitPosition;         //make the current bit 1
                    n1 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

            for (int bitPosition = 0; bitPosition < 8; bitPosition++)
            {
                // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
                if ((n1 >> bitPosition & 1) == 0 &&
                    (n0 >> bitPosition & 1) == 1)
                {
                    n1 |= 1 << bitPosition;         //make the current bit 1
                    n0 &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
                }
            }

        }

        

        //The output
        Console.WriteLine(n0);
        Console.WriteLine(n1);
        Console.WriteLine(n2);
        Console.WriteLine(n3);
        Console.WriteLine(n4);
        Console.WriteLine(n5);
        Console.WriteLine(n6);
        Console.WriteLine(n7);

    }
}



                                            /**********************************
                                             *  bitdown + arrays + bitwise    *
                                             *  *******************************/
                                            

//using System;

//class FallDown
//{
//    static void Main()
//    {
//        int [] nums = new int [8];
//        for (int i = 0; i < nums.Length; i++)
//        {
//            nums[i] = int.Parse(Console.ReadLine());
//        }

//        for (int i = 0; i < 8; i++)       // if the first bit of n7 = 0 and the first bit of n6 = 1 -> yes: bit fall down
//        {
//            for (int line = 7; line > 0; line--)        //move over the 8 given integers
//            {

//                for (int bitPosition = 0; bitPosition < 8; bitPosition++)
//                {
                   
//                    if ((nums[line] >> bitPosition & 1) == 0 &&
//                        (nums[line - 1] >> bitPosition & 1) == 1)
//                    {
//                        nums[line] |= 1 << bitPosition;         //make the current bit 1
//                        nums[line - 1] &= ~(1 << bitPosition);      //make the current bit 0 / n6 ^= (1 << bitPosition);
//                    }
//                }

//            }
//        }

//        foreach (var num in nums)
//        {
//            Console.WriteLine(num);
//        }
//    }
//}






                                         /**********************************
                                          *         bitdown + matrix       *
                                          *  *******************************/


//class FallDown
//{
//    static void Main()
//    {
//        int[,] matrix = new int[8, 8];

//        for (int row = 0; row < 8; row++)
//        {

//            int num = int.Parse(Console.ReadLine());
//            string numToString = Convert.ToString(num, 2).PadLeft(8, '0');

//            for (int col = 0; col < 8; col++)
//            {
//                matrix[row, col] = int.Parse(numToString[col].ToString());  //get the char of this position 
//            }
//        }

//        for (int col = 0; col < 8; col++)
//        {
//            int count = 0;

//            for (int row = 0; row < 8; row++)
//            {
//                if (matrix[row,col] == 1)
//                {
//                    count++;
//                    matrix[row, col] = 0;
//                }

//                for (int i = 0; i < count; i++)
//                {
//                    matrix[7 - 1, col] = 1;
//                }
//            }
//        }

//        for (int row = 0; row < 8; row++)
//        {
//            StringBuilder sb = new StringBuilder();
//            for (int col = 0; col < 7; col++)
//            {
//                sb.Append(matrix[row, col]);    //append all ones of each row
//            }
//            int num = Convert.ToInt32(sb.ToString(),2);
//            Console.WriteLine(num);
//        }
//    }
//}