using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal interface IVehicle
    {
        int Speed { get; set; }

        int SetSpeed();
        int GetSpeed();

    }
}
