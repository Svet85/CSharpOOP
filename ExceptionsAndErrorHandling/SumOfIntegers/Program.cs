﻿using System;

namespace SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int sum = 0;

            foreach (var item in array)
            {
                try
                {
                    int a = int.Parse(item);
                    sum += a;

                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                    
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

    }
}
