using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Boats : IVehicle
    {
        public int Speed { get; set; }
		public string SpeedMeassurement { get; } = "knots";
		Random random = new Random(); // har för mig att detta genererar en bättre random dvs att den initieras med klassen och inte i en metod

        //ange hastigheten
        public void SetSpeed(int newSpeed)
        {
            Speed = random.Next(10, 100);
        }

        public int GetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
