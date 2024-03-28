using Vehicle;


int numberinput = 0;
bool check = false;
List<IVehicle> vehicles = new List<IVehicle>();



while (check == false)
{
    Console.WriteLine("--Please Select-- \n1. Print/Create Cars \n2. Print/Create Boats \n3. Print/Create Motorcycles \n4. Print all vehicle in m/s");
    var input = Console.ReadLine();
    if (int.TryParse(input, out numberinput))
    {
        if (numberinput >= 1 && numberinput <= 4)
            check = true;
        else
        {
            check = false;
            Console.WriteLine("The number must be between 1-4, please try again");
            continue;
        }
    }
    else
    {
        Console.WriteLine("Please enter a number");
        continue;
    }



    switch (numberinput)
    {
        case 1:
            Car car = new Car();

            if (!vehicles.Contains(car))
                Console.WriteLine("--No cars in stock--");

            Console.WriteLine("Enter + to add new car");
            var plusinput = Console.ReadLine();
            car.SetSpeed();
            vehicles.Add(car);

            foreach (var item in vehicles)
            {
                if (item.GetType() == typeof(Car))
                {
                    Console.WriteLine("Car added ({0} mph), press any key to return to main menu.", item.Speed);
                    check = false;
                    continue;
                }
            };
            break;

        default:
            break;
    }


};

Console.Read();