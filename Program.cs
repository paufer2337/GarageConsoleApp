using System;
using System.Threading;




namespace GarageConsoleApp; 

class Program
{
    private static Garage? garage;

    static void Main()
    {

        CreateGarage();
        PopulateGarage();

        string? action = "";
        while (action != "99")
            {
                Console.Clear();
                Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ ");
                Console.WriteLine("");
                Console.WriteLine("  Welcome to the famous G A R A G E! ");
                Console.WriteLine("");
                Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀ ");
                Console.WriteLine();
                Console.WriteLine("| [1] List all parked vehicles       |");
                Console.WriteLine("| [2] Sort vehicle by type/quantity  |");
                Console.WriteLine("| [3] ADD vehicle                    |");
                Console.WriteLine("| [4] REMOVE vehicle                 |");
                Console.WriteLine("| [5] Search by registration number  |");
                Console.WriteLine("| [6] Search by vehicle properties   |");
                Console.WriteLine("| [7] Create new garage              |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("| [99] Exit");
                Console.WriteLine();
                Console.Write("Select an action: ");

                action = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(action))
                {
                    Console.WriteLine("Invalid input. Please enter a number/action from the menu.");
                    Helpers.CountDownToMenu();
                    continue;
                }

                Console.WriteLine();

                switch (action)
                {
                    case "1":
                        garage!.ParkedVehicles();
                        Helpers.Pause();
                        break;
                    
                    case "2":
                        garage!.VehiclesByType();
                        break;
                    
                    case "3":
                        AddVehicle();
                        break;
                    
                    case "4":
                        RemoveVehicle();
                        break;
                    
                    case "5":
                        SearchByRegNr();
                        break;

                    case "6":
                        SearchByProperties();
                        break;

                    case "7":
                        CreateGarage();
                        PopulateGarage();
                        break;

                    case "99":
                        Console.WriteLine("Exiting the program...");
                        Thread.Sleep(800);
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please choose a valid action from the menu.");
                        Helpers.CountDownToMenu();
                        break;
                }
  
        }
        
    }
    
    static void CreateGarage()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                               |");
        Console.WriteLine("| === BUILDING A NEW GARAGE === |");
        Console.WriteLine("|                               |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Welcome! Before using the system, you need to create a garage.");
        Console.WriteLine("|");
        Console.Write("| Please enter the capacity of the garage (number of parking spots): ");

        int capacity;
        while (!int.TryParse(Console.ReadLine(), out capacity) || capacity < 3)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid capacity for the garage (minimum 3): ");
        }
        garage = new Garage(capacity);

        Console.WriteLine("|");
        Console.WriteLine($"| ~ Garage created with {capacity} parking slots. ~");
        Thread.Sleep(1500);
    }

    static void PopulateGarage()
    {
        Console.Clear();
        Console.WriteLine("▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine();
        Console.WriteLine("===== POPULATE GARAGE FROM START =====");
        Console.WriteLine();
        Console.WriteLine("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.Write("| Do you want to add vehicles from start? (y/n): ");

        string? input = Console.ReadLine();

        if (input?.ToLower() != "y")
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("~ Garage starts empty. ~");
            Helpers.CountDownToMenu();
            return;
        }
        
        Console.WriteLine("|");
        Console.WriteLine("| How many vehicles do you want to add? (max " + garage!.Capacity + "): ");

        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1 || amount > garage!.Capacity)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid number of vehicles to add (1-" + garage!.Capacity + "): ");
        }

        Console.Clear();

        for (int i = 0; i < amount; i++)
        {
            AddVehicle();
        }
        
    }

    static void AddVehicle()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("| ==== ADD A NEW VEHICLE ==== |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Adding a new vehicle to the garage.");
        Console.WriteLine("|");
        Console.WriteLine("| [1] Car");
        Console.WriteLine("| [2] Motorcycle");
        Console.WriteLine("| [3] Bus");
        Console.WriteLine("| [4] Boat");
        Console.WriteLine("| [5] Airplane");
        Console.WriteLine("|");
        Console.WriteLine("| [0] Back");
        Console.WriteLine();
        Console.Write("Select vehicle type: ");

        string? action = Console.ReadLine();

        if (action == "0")
        {
            return;
        }

        Console.WriteLine();

        string regNumber = Helpers.GetValidText("Enter registration number: ").Replace(" ", "").Replace("-", "").ToUpper();
        string color = Helpers.GetValidText("Enter color: ");
        int wheelAmount = Helpers.GetValidInt("Enter number of wheels: ");

        Vehicle? vehicle = null;
        switch (action)
        {
            case "1":
                vehicle = new Car(regNumber, color, wheelAmount);
                break;
            case "2":
                vehicle = new Motorcycle(regNumber, color, wheelAmount);
                break;
            case "3":
                vehicle = new Bus(regNumber, color, wheelAmount);
                break;
            case "4":
                vehicle = new Boat(regNumber, color, wheelAmount);
                break;
            case "5":
                vehicle = new Airplane(regNumber, color, wheelAmount);
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid selection.");
                Helpers.CountDownToMenu();
                return;
        }

        Console.WriteLine();
        bool added = garage!.AddVehicle(vehicle);

        Console.WriteLine();

        if (added)
        {
            Console.WriteLine($"Vehicle {vehicle.RegNumber} added to the garage.");
        }
        else
        {
            Console.WriteLine("Garage is full or a vehicle with the same registration number already exists..");
        }
        
        Helpers.CountDownToMenu();
    } 


    static void RemoveVehicle()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("| ==== REMOVE A VEHICLE ====  |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Removing a vehicle from the garage.");
        Console.WriteLine("|");
        string regNumber = Helpers.GetValidText("| Enter registration number of the vehicle to remove: ").ToUpper();

        bool removed = garage!.RemoveVehicle(regNumber);

        Console.WriteLine();

        if (removed)
        {
            Console.WriteLine($"Vehicle {regNumber} removed from the garage.");
        }
        else
        {
            Console.WriteLine($"No vehicle with registration number {regNumber} found in the garage.");
        }

        Helpers.CountDownToMenu();
    } 

    static void SearchByRegNr()
    {
        Console.Clear();
        Console.WriteLine(" ▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine("|                             |");
        Console.WriteLine("|   SEARCH VEHICLE BY REGNR   |");
        Console.WriteLine("|                             |");
        Console.WriteLine(" ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
        Console.WriteLine();
        Console.WriteLine("| Searching for a vehicle by registration number.");
        Console.WriteLine("|");
        string regNumber = Helpers.GetValidText("| Enter registration number to search: ").ToUpper();

        Vehicle? foundVehicle = garage!.FindByRegNr(regNumber);

        Console.WriteLine();

        if (foundVehicle != null)
        {
            Console.WriteLine("Vehicle found:");
            Console.WriteLine(foundVehicle.GetInfo());
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"No vehicle with registration number {regNumber} found in the garage.");
        }

        Helpers.CountDownToMenu();
    } 

    
}