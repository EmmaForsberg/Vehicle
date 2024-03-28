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

        public int GetSpeed()
        {
            throw new NotImplementedException();
        }

        public int SetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
