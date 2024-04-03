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
		var input = Console.ReadLine(); //denna skulle kunna vara ReadKey
		if (int.TryParse(input, out numberinput))
		{
			if (numberinput >= 1 && numberinput <= 4) 
			{
				check = true;
				var enumType = Enum.Parse(typeof(VehicleEnum), numberinput.ToString());
                Console.WriteLine(enumType.ToString());
                SelectedNumber(numberinput); //byt ut siffror mot enum, ger tydlighet istället för att inte veta vilken siffra representerar vad, samt enklare att ändra/ lägga till fordon, kontrollera text
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
			if (vehicles.Count is 0) // Detta kontrollerar bara fordon, ej typ
			{
				CreateVehicle(car); // bilen bör skapas i metoden och isf retuneras, inte på raden innan
									// jag antar det är för du ville använda samma variabel i else? Fast där vill du väl igentligen ha en lista på alla bilar?
									// Och om den hamnar i else så kommer den ej ha gått igenom if så den kommer alltid vara ett tomt objekt
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
		case 3:
			IVehicle bike; // vill du ha denna variabel här så går det såklart men skapa ej objektet här
			if (!vehicles.Any(x => x is Boats)) // finns det någon båt i listan !
			{
				bike = AddVehicle(VehicleEnum.Boat);
			}
			else
			{

			}
			break;
		default:
			break;
		// flyttade listningen från Add till egen metod ListVehiclesOfType, men denna är snarlik PrintVehicleInStock() går dessa att sammanfoga helt eller delvis kanske?
		// eftersom alla else har samma sak så kan du skippa den om du får odning på texten och bara skriva ut på ett ställe istället
	}
}


void CreateVehicle(IVehicle vehicle)
{
	// ev. ändra namnet på metoden till ConfirmVehicleCreation
	Console.WriteLine("--No cars in stock--"); // om man använt en enum så går det skriva en dataannotation på den och hämta för användning här
	Console.WriteLine("Enter + plus to add a new car.");
	var plusinput = Console.ReadLine(); // den bör kolla här om man skrivit +, inte skicka vidare och sedan kolla
	//AddVehicle(plusinput, vehicle);
}

IVehicle AddVehicle(VehicleEnum vehicleType)
{
	IVehicle? vehicle = null;
	switch (vehicleType)
	{
		case VehicleEnum.Car:
			vehicle = new Car();
			vehicle.SetSpeed();
			break;
		case VehicleEnum.Boat:
		case VehicleEnum.Motorcykle:
		default:
			break;
	}

	vehicles.Add(vehicle); // kolla om null
	return vehicle;
}

void ListVehiclesOfType(VehicleEnum vehicleEnum)
{
	foreach (var item in vehicles) // lättare att filtrera listan redan här
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

void ChangeVehicle(IVehicle vehicle)
{
	Console.WriteLine("Please select car to change (0-9) or enter + to add a new car");
	var choice = Console.ReadLine();

	if (choice == "+")
	{
		//AddVehicle(choice, vehicle);// den bör kolla innan om man skrivit rätt, inte skicka vidare och sedan kolla (vilket du redan har gjort i if)
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
			var newinput = Convert.ToInt32(input);
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