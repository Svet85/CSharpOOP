﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {
        }

        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
