using System.Diagnostics;
using Vehicle;// lägg gärna till luft mellan sektioner, ökar läsbarhet

int numberinput = 0;
bool check = false;

List<IVehicle> carlist = new List<IVehicle>();
List<IVehicle> boatlist = new List<IVehicle>();
List<IVehicle> vehicles = new List<IVehicle>(); // tycker det är onödigt att ha olika listor, säg till om det är ngt specifikt med en lista som du kör fast med

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
				check = true; // gärna ett tydligare namn på denna

				// notera att detta bara kommer att fungera för fordonen just nu, dvs '4' kommer ej fungera
				// du kan göra en till if för '4', ändra namnet VehicleEnum till MenuOptionEnum och lägga till alternativet
				// eller skapa fler nivåer på menyn, välj sjäv vad du tycker blir snyggast
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
											//edit: I carlist kommer det bara finnas bilar så det skulle isf räcka med .Any() 
			{
				CreateVehicle(VehicleEnum.Car);
			}
			else //
			{
				Console.WriteLine("-- " + carlist.Count + " cars in stock--");
				PrintVehiclesOfType(VehicleEnum.Car);
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
				PrintVehiclesOfType(VehicleEnum.Boat);
			}
			break;

		default:
			break;
	}
}

void CreateVehicle(object enumtype) // varför object, du vet ju att det är ett VehicleEnum?
{
	Console.WriteLine($"--No {enumtype}s in stock--");
	Console.WriteLine($"Enter + plus to add a new {enumtype}.");
	var plusinput = Console.ReadLine(); // koll här så att input är en +

	if (plusinput == "+")
		AddVehicle(enumtype);

	// just nu är dina metoder kopplade i serie dvs. a > b > c > d
	// jag ser hellre att att det returnerar och sedan fortsätter a > b, a > c, a > d
	// att du har en "kontroll metod", vilket ger en bättre överblick om vad som körs
	//
	// Som det är nu har du inte koll var dina metoder hamnar,
	// i detta fall når de "PrintLatestAddedVehicle" där de kör PrintMenu()
	// och sedan hoppar de tillbaka hit och kör PrintMenu() en gång till
	//
	// Tänk på att metoder ska helst ha ETT syfte, exempel AddVehicle ska bara lägga till
	// generellt så kan du tänka att om du behöver använda "och" när du beskriver syftet
	// så kan det vara bättre att göra den saken någon annanstanns eller att köra en return

	PrintMenu();
}

IVehicle AddVehicle(object enumtype) // Du verkar ej anväda returen av denna, kan den vara void istället?
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
			break; // gör du istället en return här så slipper du varningen nedan om possible null
	}

	PrintLatestAddedVehicle(vehicle);
	return vehicle;
}

void PrintLatestAddedVehicle(IVehicle vehicle) // alternativt skicka enum?
{
	var vehicleAlt = vehicles.Last(); // eftersom du redan skickar med denna redan så kan du skippa detta eller ta bort parametern,
									  // vad vill du egentligen skriva ut, objektet du skickat med eller det sista i listan, kan det vara skillnad på detta?
	if (vehicleAlt is Car)
	{
		Console.WriteLine($"Car nr. {vehicles.Count(x => x is Car)} added on index {vehicles.FindIndex(x => x == vehicleAlt)}" +
			$"{vehicleAlt.GetSpeed()} {vehicleAlt.SpeedMeasurement}, press any key to return to the main menu.");
	}


	if (vehicle is Car && carlist.Any())
	{
		var lastCar = carlist.Last();
		Console.WriteLine("Car {0} added {1} mph, press any key to return to the main menu.", carlist.Count - 1, lastCar.GetSpeed()); // Count -1 ger index, är det det du vill ha?
	}
	else if (vehicle is Boat && boatlist.Any())
	{
		var lastBoat = boatlist.Last();
		Console.WriteLine("Boat {0} added {1} knots, press any key to return to the main menu.", boatlist.Count - 1, lastBoat.GetSpeed());
		//Console.WriteLine($"Boat {boatlist.Count - 1} added {lastBoat.GetSpeed()} knots, press any key to return to the main menu."); // kan också skrivas såhär, beror på preferens
	}
	PrintMenu();
}

void ChangeVehicle(List<IVehicle> vehicleList, object vehicle)
{
	Console.WriteLine($"Please select {vehicle} to change (0-9) or enter + to add a new {vehicle}"); //jag ser ej att du begränsat listan till 10 nånstanns
	// kanske bättre att använda en array om varje siffra ska kopplas till ett specifikt fordon
	// tar jag bort fjärde objektet i en lista så kommer allt att flyttas en position till vänster
	// på en array skulle den platsen bli tom och inget skulle flyttas (alternativt använda en dictionary)

	var choice = Console.ReadLine();

	if (choice == "+")
	{
		AddVehicle(vehicle);
	}
	else
	{
		int numberchoice = Convert.ToInt32(choice); // kommer denna kasta fel om det inte är siffra? kanske tryparse är mer passande?

		Console.WriteLine($"--{vehicle} {numberchoice}--");
		Console.WriteLine("Speed: {0} mph", vehicleList[numberchoice].GetSpeed()); // ändra hastighet
		Console.WriteLine("Enter new speed(0-100) or - to remove boat");
		var input = Console.ReadLine();
		if (input == "-")
		{
			RemoveVehicle(vehicleList, vehicleList[numberchoice]);
		}
		else
		{
			var newinput = Convert.ToInt32(input);
			// här ska det skapas en ny hastighet för valt fordon
			IVehicle vehiclex = new Car(newinput); //osäker varför nytt skapas?
			vehicleList[numberchoice] = vehiclex;

//			vehicleList[numberchoice].SetSpeed(newinput);

			PrintMenu();
		}
	}
}


void RemoveVehicle(List<IVehicle> vehicleList, IVehicle vehicle) //enum för att ersätta texten?
{
	vehicleList.Remove(vehicle);
	//vehicles.Remove(vehicle); // ?
	Console.WriteLine("Car removed, press any key to return to main menu");
	PrintMenu(); // risken med detta är att du går djupare och djupare i en loop och äter minne.
				 // kanske du hellre kan flytta ut check från PrintMenu() och sätta den till false här? 
				 // då kommer du tillbaka till PrintMenu metoden efter allt annat har körts klart
}


void PrintVehiclesOfType(object enumobject) // samma som tidigare, varför inte ta in det som en enum redan här?
{
	// Kan enkelt ändras i samma stil som PrintLatestAddedVehicle()
	if (enumobject is VehicleEnum vehicleType)
	{
		switch (vehicleType)
		{
			case VehicleEnum.Car:
				if (carlist.Any())
				{
					for (int i = 0; i < carlist.Count; i++)
					{
						Console.WriteLine("Car {0} - {1} mph", i, carlist[i].GetSpeed());

					}
					ChangeVehicle(carlist, enumobject); // denna borde flyttas ut till kontroll metod/ har ej ngt med print att göra
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
						Console.WriteLine("Boat {0} - {1} knots", i, boatlist[i].GetSpeed());
					}
					ChangeVehicle(boatlist, enumobject);
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
}

Console.Read();