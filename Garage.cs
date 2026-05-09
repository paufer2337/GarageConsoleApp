using System;





namespace GarageConsoleApp;


class Garage
{
    private Vehicle?[] vehicles;

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new Vehicle?[capacity];
    }

    public int Capacity { get; }
}