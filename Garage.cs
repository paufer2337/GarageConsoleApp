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

    public void ParkedVehicles()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ ");
        Console.WriteLine("|                                   |");
        Console.WriteLine("|   PARKED VEHICLES IN THE GARAGE   |");
        Console.WriteLine("|                                   |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀ ");
        Console.WriteLine();

        bool foundVehicle = false;
        int vehicleNr = 1;

        Console.WriteLine("| No.   Type            RegNr       Color         Wheels |");
        Console.WriteLine("| ------------------------------------------------------ |");

        foreach (Vehicle? parkedVehicle in vehicles)
        {
            if (parkedVehicle != null)
            {
                Console.WriteLine($"| [{vehicleNr}] {parkedVehicle.GetType().Name,-15} {parkedVehicle.RegNumber,-12} {parkedVehicle.Color,-14} {parkedVehicle.WheelAmount,-6} |");
                vehicleNr++;
                foundVehicle = true;
            }
        }

        if (!foundVehicle)
        {
            Console.WriteLine("~ No parked vehicles found. ~");
        }
    }
}