using System; // ta bort alla onödiga usings
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
	internal enum VehicleEnum
	{
		Car = 1,
		Boat = 2,
		Motorcycle = 3
	}

	internal interface IVehicle
	{
		int Speed { get; set; } // kommer detta vara uttryckt mph knots km/h?
		string SpeedMeassurement { get; }

		void SetSpeed(int newSpeed); // från m/s till fordonets specifika?
		int GetSpeed(); // och att uträkning till m/s ska ske här?
	}
}
