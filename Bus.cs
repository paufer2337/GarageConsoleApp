using System;
using System.Collections.Generic;
using System.Threading;



namespace GarageConsoleApp;

class Bus : Vehicle
{
    public Bus(string regNumber, string color, int wheelAmount)
        : base(regNumber, color, wheelAmount)
    {
    }
}