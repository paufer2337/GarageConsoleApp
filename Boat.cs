using System;
using System.Collections.Generic;
using System.Threading;



namespace GarageConsoleApp;

class Boat : Vehicle
{
    public double Length { get; }

    public Boat(string regNumber, string color, int wheelAmount, double length)
        : base(regNumber, color, wheelAmount)
    {
        Length = length;
    }

    public override string GetExtraInfo()
    {
        return $"{Length} m";
    }
}