using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public Smartphone()
        {
        }

        public void Browsing(string URL)
        {
            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
