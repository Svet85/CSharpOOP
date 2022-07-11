using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IRobot : IId
    {
        string Model { get; set; }
    }
}
