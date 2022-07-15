using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        protected Food(double quantity)
        {
            Quantity = quantity;
        }

        public double Quantity { get; set; }
    }
}
