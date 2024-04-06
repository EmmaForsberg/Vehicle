using System.Diagnostics;
using Vehicle;
int numberinput = 0;
bool check = false;
List<IVehicle> carlist = new List<IVehicle>();
List<IVehicle> boatlist = new List<IVehicle>();
Random random = new Random();


PrintMenu();
//SelectedNumber(numberinput);


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
                var enumType = Enum.Parse(typeof(VehicleEnum), numberinput.ToString());

                SelectedNumber(enumType);
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

void SelectedNumber(object EnumType)
{
    switch (EnumType)
    {
        case VehicleEnum.Car:
            if (!carlist.Any(x => x is Car))//om det inte finns några bilar går den in i denna metod
            {
                CreateVehicle(VehicleEnum.Car);
            }
            else //
            {
                Console.WriteLine("-- " + carlist.Count + " cars in stock--");
                PrintVehicleInStock(VehicleEnum.Car);
            }
            break;

        case VehicleEnum.Boat:
            if (!boatlist.Any(x => x is Boat))//om det inte finns några båtar går den in i denna metod
            {
                CreateVehicle(VehicleEnum.Boat);
            }
            else //
            {
                Console.WriteLine("-- " + boatlist.Count + " boats in stock--");
                PrintVehicleInStock(VehicleEnum.Boat);
            }
            break;

        default:
            break;
    }
}

void CreateVehicle(object enumtype)
{
    Console.WriteLine($"--No {enumtype}s in stock--");
    Console.WriteLine($"Enter + plus to add a new {enumtype}.");
    var plusinput = Console.ReadLine(); // koll här så att input är en +
    if (plusinput == "+")
        AddVehicle(enumtype);
    PrintMenu();
}

IVehicle AddVehicle(object enumtype)
{
    int randomNumber = random.Next(1, 100);
    IVehicle? vehicle = null;
    switch (enumtype)
    {
        case VehicleEnum.Car:
            vehicle = new Car(randomNumber);
            carlist.Add(vehicle);
            break;


        case VehicleEnum.Boat:
            vehicle = new Boat(randomNumber);
            boatlist.Add(vehicle);
            break;


        default:
            break;
    }

    PrintLatestAddedVehicle(vehicle);
    return vehicle;
}

void PrintLatestAddedVehicle(IVehicle vehicle)
{
    if (vehicle is Car && carlist.Any())
    {
        var lastCar = carlist.Last();
        Console.WriteLine("Car {0} added {1} mph, press any key to return to the main menu.", carlist.Count - 1, lastCar.speed);
        PrintMenu();
    }
    else if (vehicle is Boat && boatlist.Any())
    {
        var lastBoat = boatlist.Last();
        Console.WriteLine("Boat {0} added {1} knots, press any key to return to the main menu.", boatlist.Count - 1, lastBoat.speed);
        PrintMenu();
    }
}

void ChangeVehicle(object vehicle)
{
    Console.WriteLine($"Please select {vehicle} to change (0-9) or enter + to add a new {vehicle}");
    var choice = Console.ReadLine();

    if (choice == "+")
    {
        AddVehicle(vehicle);
    }
    else
    {
        int numberchoice = Convert.ToInt32(choice);

        Console.WriteLine($"--{vehicle} {0}--", numberchoice);
        Console.WriteLine("Speed: {0} mph", carlist[numberchoice].speed);// skicka med en lista till denna metod?
        Console.WriteLine("Enter new speed(0-100) or - to remove boat");
        var input = Console.ReadLine();
        if (input == "-")
        {
            RemoveVehicle(carlist[numberchoice]);
        }
        else // new speed
        {
            var newinput = Convert.ToInt32(input);
            IVehicle vehiclex = new Car(newinput);
            carlist[numberchoice] = vehiclex;
            PrintMenu();
        }
    }
}


void RemoveVehicle(IVehicle vehicle)
{
    carlist.Remove(vehicle);
    Console.WriteLine("Car removed, press any key to return to main menu");
    PrintMenu();
}


void PrintVehicleInStock(object enumobject)
{
    if (enumobject is VehicleEnum vehicleType)
    {
        switch (vehicleType)
        {
            case VehicleEnum.Car:
                if (carlist.Any())
                {
                    for (int i = 0; i < carlist.Count; i++)
                    {
                        Console.WriteLine("Car {0} - {1} mph", i, carlist[i].speed);
                    }
                }
                else
                {
                    Console.WriteLine("No cars in stock.");
                }
                break;

            case VehicleEnum.Boat:
                if (boatlist.Any())
                {
                    for (int i = 0; i < boatlist.Count; i++)
                    {
                        Console.WriteLine("Boat {0} - {1} knots", i, boatlist[i].speed);
                    }
                }
                else
                {
                    Console.WriteLine("No boats in stock.");
                }
                break;

            default:
                Console.WriteLine("Invalid vehicle type.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid parameter. Please provide a valid VehicleEnum.");
    }
    ChangeVehicle(enumobject);
}

Console.Read();