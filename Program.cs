using Vehicle;
int numberinput = 0;
bool check = false;
List<IVehicle> vehicles = new List<IVehicle>();


PrintMenu();
SelectedNumber(numberinput);

void PrintMenu()
{
    do
    {
        Console.WriteLine("--Please Select-- \n1. Print/Create Cars \n2. Print/Create Boats \n3. Print/Create Motorcycles \n4. Print all vehicle in m/s");
        var input = Console.ReadLine();
        if (int.TryParse(input, out numberinput))
        {
            if (numberinput >= 1 && numberinput <= 4)
            {
                check = true;
                SelectedNumber(numberinput);
            }
            else
            {
                Console.WriteLine("The number must be between 1-4, please try again");
                check = false;
            }
        }
        else
        {
            Console.WriteLine("Please enter a number");
            check = false;
        }

    } while (check == false);
}

void SelectedNumber(int number)
{
    switch (number)
    {
        case 1:

            IVehicle car = new Car();
            if (vehicles.Count is 0)
            {
                CreateVehicle(car);
            }
            else
            {
                Console.WriteLine("-- " + vehicles.Count + " cars in stock--");
                PrintVehicleInStock(car);

            }
            break;

        case 2:
            IVehicle boat = new Boats();
            if (vehicles.Count is 0)
            {
                CreateVehicle(boat);
            }
            else
            {
                Console.WriteLine("-- " + vehicles.Count + " boats in stock--");
                PrintVehicleInStock(boat);
            }
            break;

        default:
            break;
    }
}

void CreateVehicle(IVehicle vehicle)
{
    Console.WriteLine("--No cars in stock--");
    Console.WriteLine("Enter + plus to add a new car.");
    var plusinput = Console.ReadLine();
    AddVehicle(plusinput, vehicle);
}

void AddVehicle(string input, IVehicle vehicle)
{
    if (input == "+")
    {
        vehicle.SetSpeed();
        vehicles.Add(vehicle);
        foreach (var item in vehicles)
        {
            if (item.GetType() == typeof(Car))
            {
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.WriteLine("Car {0} added {1} mph, press any key to return to main menu.", i, vehicles[i].Speed);
                };

                PrintMenu();
            }
        };
    }
}

void ChangeVehicle(IVehicle vehicle)
{
    Console.WriteLine("Please select car to change (0-9) or enter + to add a new car");
    var choice = Console.ReadLine();

    if (choice == "+")
    {
        AddVehicle(choice, vehicle);
    }
    else
    {
        int numberchoice = Convert.ToInt32(choice);

        Console.WriteLine("--Car {0}--", numberchoice);
        Console.WriteLine("Speed: {0} mph", vehicles[numberchoice].Speed);
        Console.WriteLine("Enter new speed(0-100) or - to remove boat");
        var input = Console.ReadLine();
        if (input == "-") 
        {
            RemoveVehicle(vehicles[numberchoice]);
        }
        else
        {
            var newinput =Convert.ToInt32(input);
            vehicles[numberchoice].Speed = newinput;
        }
    }
}

void RemoveVehicle(IVehicle vehicle)
{
    vehicles.Remove(vehicle);
    Console.WriteLine("Car removed, press any key to return to main menu");
    PrintMenu();
}

void PrintVehicleInStock(IVehicle vehicle)
{
    foreach (var item in vehicles)
    {
        if (item.GetType() == typeof(Car))
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine("Car {0} - {1} mph", i, vehicles[i].Speed);
            };
        }
        ChangeVehicle(vehicle);
    };
}
Console.Read();