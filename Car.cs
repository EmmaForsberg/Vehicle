using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Vehicle; // namespace kan numera även skrivas såhär, det är mer en smaksak, gör ingen skillnad kodmässigt. Viktigast bara att hålla det konsistent isf
namespace Vehicle
{
    internal class Car : IVehicle
    {
        int _speed = 0; // ofta vanligt att markera privata variabler med _

        public string SpeedMeasurement {  get; private set; }

        //konstruktor här
        public Car(int randomSpeed)
        {
            _speed = randomSpeed;
            SpeedMeasurement = "mph";
        }


        public void SetSpeed(int Speed) // denna parameter bör ej börja med caps
        {
            _speed = Speed;
        }


        public int GetSpeed()
        {
            return _speed;
        }
    }
}
