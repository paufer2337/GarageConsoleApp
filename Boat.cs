using System;
using System.Collections.Generic;
using System.Threading;



namespace GarageConsoleApp;

class Boat : Vehicle
{
    public Boat(string regNumber, string color, int wheelAmount)
        : base(regNumber, color, wheelAmount)
    {
    }
}