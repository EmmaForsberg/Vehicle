using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Functions
    {
        List<IVehicle> carList = new List<IVehicle>();
        Random random = new Random();
       
        public void testmetod()
        {
            int randomNumber = random.Next(1, 100);
            Car car = new Car(randomNumber);
            carList.Add(car);
            for (int i = 0; i < carList.Count; i++)
           {
                Console.WriteLine("Car {0} - {1} mph", i, carList[i].speed);
           };
        }
    }
}
