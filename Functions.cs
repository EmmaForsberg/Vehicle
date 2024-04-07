namespace Vehicle
{
	internal class Functions // detta namn är kasst xD Vad ska finnas här? hjälpmetoder? testmetoder?
    {
        List<IVehicle> carList = new List<IVehicle>();
        Random random = new Random();
       
        public void testmetod()
        {
            //om detta ska användas som test så ta ett default värde istället för random, så att du har ngt att jämnföra med

            int randomNumber = random.Next(1, 100);
            Car car = new Car(randomNumber);
            carList.Add(car);
            for (int i = 0; i < carList.Count; i++)
           {
                Console.WriteLine("Car {0} - {1} mph", i, carList[i].GetSpeed());
           };
        }
    }
}
