using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen : IId, IBirthable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
