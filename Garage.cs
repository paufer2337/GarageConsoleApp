using System;





namespace GarageConsoleApp;


class Garage
{
    private Vehicle?[] vehicles;

    public Garage(int capacity)
    {
        vehicles = new Vehicle?[capacity];
    }
}