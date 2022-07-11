using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IRobot : IId
    {
        string Model { get; set; }
    }
}
