using System;
using System.Collections.Generic;
using System.Threading;



namespace GarageConsoleApp;

class Motorcycle : Vehicle
{
    public Motorcycle(string regNumber, string color, int wheelAmount)
        : base(regNumber, color, wheelAmount)
    {
    }
}