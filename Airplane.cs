using System;
using System.Threading;


namespace GarageConsoleApp;

class Airplane : Vehicle
{
    public int EngineAmount { get; }

    public Airplane(string regNumber, string color, int wheelAmount, int engineAmount)
        : base(regNumber, color, wheelAmount)
    {
        EngineAmount = engineAmount;
    }

    public override string GetExtraInfo()
    {
        return $"{EngineAmount} engines";
    }
}