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
                    CountDownToMenu();
                    continue;
                }

                Console.WriteLine();

                switch (action)
                {
                   /* case "1":
                        garage!.ParkedVehicles();
                        break;

                    case "2":
                        garage!.VehiclesByType();
                        break;
                    */
                    case "3":
                        AddVehicle();
                        break;
                    /*
                    case "4":
                        RemoveVehicle();
                        break;

                    case "5":
                        SearchByRegNr();
                        break;

                    case "6":
                        SearchByProperties();
                        break;
*/
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
                        CountDownToMenu();
                        break;
                }
  
        }
        
    }
    
    static void CreateGarage()
    {
        Console.Clear();
        Console.WriteLine("▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine();
        Console.WriteLine("=== BUILDING A NEW GARAGE ===");
        Console.WriteLine();
        Console.WriteLine("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
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
            CountDownToMenu();
            return;
        }
        Console.Clear();
        Console.WriteLine("How many vehicles do you want to add? (max " + garage!.Capacity + "): ");

        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1 || amount > garage!.Capacity)
        {
            Console.WriteLine();
            Console.Write("| Invalid input. Please enter a valid number of vehicles to add (1-" + garage!.Capacity + "): ");
        }

        for (int i = 0; i < amount; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Adding vehicle {i + 1} of {amount}...");
            Console.WriteLine();
            AddVehicle();
        }
    }

    static void AddVehicle()
    {
        Console.Clear();
        Console.WriteLine("▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
        Console.WriteLine();
        Console.WriteLine("===== ADD A NEW VEHICLE =====");
        Console.WriteLine();
        Console.WriteLine("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");
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

        string regNumber = GetValidText("Enter registration number: ").ToUpper();
        string color = GetValidText("Enter color: ");
        int wheelAmount = GetValidInt("Enter number of wheels: ");

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
                CountDownToMenu();
                return;
        }
        
    }   

    static string GetValidText(string message)
    {
        Console.Write(message);
        
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            
            Console.WriteLine("Input cannot be empty. Please try again.");
            Console.WriteLine();
            input = Console.ReadLine();
        }
     

        return input;
    }

    static int GetValidInt(string message)
    {
        Console.Write(message);
        
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid non-negative integer.");
            Console.WriteLine();
        }

        return value;
    }

    static double GetValidDouble(string message)
    {
        Console.Write(message);
        
        double value;
        while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.WriteLine();
        }

        return value;
    }


    static void CountDownToMenu()
    {
        Console.WriteLine();

        for (int i = 3; i > 0; i--)
        {
            Console.Write($"\rReturning to menu in {i}...   ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();

    }
}