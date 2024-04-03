using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
	internal class Car : IVehicle
	{
		public int Speed { get; set; }
		public string SpeedMeassurement { get; } = "knots";

		//ange hastigheten
		public void SetSpeed(int newSpeed)
		{
			var random = new Random();
			Speed = random.Next(10, 100);
		}

		//returnera hastigheten
		public int GetSpeed()
		{
			throw new NotImplementedException();
		}

	}
}
