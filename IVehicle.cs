namespace Vehicle
{
    internal enum VehicleEnum
    {
		// https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations
		Car = 1,
        Boat = 2,
        Motorcycle = 3
    }
    internal interface IVehicle
    {
		                     // publika variabler bör vara med CamelCase
        //int speed { get; } // tror det var jag som introducerade denna men eftersom GetSpeed och SetSpeed finns så bör den kanske inte finnas (vad är syftet att kunna komma åt den via interfacet)
                             // detta hade kanske varit mer lämligt om detta varit en basklass
		string SpeedMeasurement { get;}

        void SetSpeed(int speed); // vill bara vara tydlig med att denna "speed" inte är samma som ovan variabel
        int GetSpeed();

    }
}
