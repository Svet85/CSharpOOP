using System;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;


            while (true)
            {
                string[] cmd = Console.ReadLine().Split();
                string action = cmd[0];
                try
                {
                    int number_1 = int.Parse(cmd[1]);

                    if (action == "Replace")
                    {
                        int number_2 = int.Parse(cmd[2]);
                        array[number_1] = number_2;
                    }
                    else if (action == "Show")
                    {
                        Console.WriteLine(array[number_1]);
                    }
                    else if (action == "Print")
                    {
                        int number_2 = int.Parse(cmd[2]);
                        Print(number_1, number_2,array);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    counter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    counter++;
                }

                if (counter == 3)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        public static void Print(int start, int end ,int[] array)
        {
            if ((start < 0 || start >= array.Length) || (end < 0 || end >= array.Length))
            {
                throw new IndexOutOfRangeException();
            }

            int[] array1 = new int[(end - start) + 1];
            for (int i = start, k = 0; i <= end; i++,k++)
            {
                array1[k] = array[i];
            }

            Console.WriteLine(string.Join(", ", array1));
        }
    }
}
