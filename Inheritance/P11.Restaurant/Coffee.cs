using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMillililters = 50;
        public Coffee(string name, double caffeine) : base(name, CoffeePrice,CoffeeMillililters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
