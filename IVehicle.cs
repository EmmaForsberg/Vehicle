namespace Vehicle
{
    internal enum VehicleEnum
    {
        Car = 1,
        Boat = 2,
        Motorcycle = 3
    }
    internal interface IVehicle
    {
        int speed { get;}
        string SpeedMeasurement { get;}

        void SetSpeed(int speed);
        int GetSpeed();

    }
}
