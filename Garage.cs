using System;





namespace GarageConsoleApp;


class Garage
{
    private Vehicle?[] vehicles;
    public int Capacity { get; }

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new Vehicle?[capacity];
    }

    
    public bool AddVehicle(Vehicle vehicle)
    {
        
        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null && parkedVehicle.RegNumber.ToUpper() == vehicle.RegNumber.ToUpper())
            {
                return false;
            }
        }

        for (int i = 0; i < Capacity; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                return true;
            }
        }
        return false;
    }
}