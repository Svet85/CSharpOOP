using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizen : IId, IBirthable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
