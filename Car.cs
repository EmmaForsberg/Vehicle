﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Car : IVehicle
    {
        public int speed { get; private set; }

        public string SpeedMeasurement {  get; private set; }

        //konstruktor här
        public Car(int randomSpeed)
        {
            speed = randomSpeed;
            SpeedMeasurement = "mph";
        }


        public void SetSpeed(int Speed)
        {
            speed = Speed;
        }


        public int GetSpeed()
        {
            return speed;
        }
    }
}
