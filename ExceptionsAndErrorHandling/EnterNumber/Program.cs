using System;
using System.Collections.Generic;

namespace EnterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int start = 1;

            while (numbers.Count < 10)
            {
                string a = Console.ReadLine();
                try
                {
                    int number = ReadNumber(start, 100, a);
                    numbers.Add(number);
                    start = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end , string input)
        {
            int number = int.Parse(input);
            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
