using System;
using System.Collections.Generic;
using System.Threading;


namespace GarageConsoleApp;

class Airplane : Vehicle
{
    public Airplane(string regNumber, string color, int wheelAmount)
        : base(regNumber, color, wheelAmount)
    {
    }
}