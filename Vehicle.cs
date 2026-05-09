using System;
using System.Collections.Generic;




namespace GarageConsoleApp;

public abstract class Vehicle
{
    
    public string RegNumber { get; }
    public string Color { get; }
    public int WheelAmount { get; }

    protected Vehicle(string regNumber, string color, int wheelAmount)
    {
        RegNumber = regNumber.ToUpper();
        Color = color;
        WheelAmount = wheelAmount;
    }

    public virtual string GetInfo()
    {
        return $"{GetType().Name} | Reg: {RegNumber} | Color: {Color} | Wheels: {WheelAmount}";
    }

}