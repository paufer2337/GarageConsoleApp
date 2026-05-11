using System;
using System.Collections.Generic;
using System.Threading;





namespace GarageConsoleApp;

class Car : Vehicle
{
    public string FuelType { get; }
    
    public Car(string regNumber, string color, int wheelAmount, string fuelType)
        : base(regNumber, color, wheelAmount)
    {
        FuelType = fuelType;
    }

    public override string GetExtraInfo()
    {
        return $"{FuelType}";
    }
}