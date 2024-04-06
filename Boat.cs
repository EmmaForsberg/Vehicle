using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Boat : IVehicle
    {
        public int speed { get; private set; }
        public string SpeedMeasurement { get; private set; }

        public Boat(int randomSpeed)
        {
            speed = randomSpeed;
            SpeedMeasurement = "knots";
        }

        //ange hastigheten
        public void SetSpeed(int Speed)
        {
            speed = Speed;        
        }

        public int GetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
