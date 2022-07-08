using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var smart = new Smartphone();
            var stationary = new StationaryPhone();

            foreach (var number in numbers)
            {
                var match = new Regex(@"^\d+$");

                if (match.IsMatch(number))
                {
                    if (number.Length == 10)
                    {
                        smart.Call(number);
                    }
                    else if (number.Length == 7)
                    {
                        stationary.Call(number);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var address in sites)
            {
                var match = new Regex(@"^\D+$");

                if (match.IsMatch(address))
                {
                    smart.Browsing(address);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
