using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IStationaryPhone
    {
        abstract void Call(string number);
    }
}
