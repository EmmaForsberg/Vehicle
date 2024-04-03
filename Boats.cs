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

        //ange hastigheten
        public int SetSpeed()
        {
            var random = new Random();
            Speed = random.Next(10, 100);
            return Speed;
        }

        public int GetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
