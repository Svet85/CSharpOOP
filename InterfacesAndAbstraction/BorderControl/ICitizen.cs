using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen : IId
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
