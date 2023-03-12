using SPV.Models;

namespace SPV.Utils
{
    //Cordinates class z uporabo longitude in latitude
    public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    //class za računanje razdalje od uporabnika do restavracije
    public static class CoordinatesDistance
    {
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }
        // funkcija za racunanje razdalje od uporabnika do restavracije v metrih
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates, UnitOfLength unitOfLength)
        {
            var d1 = baseCoordinates.Latitude * (Math.PI / 180.0);
            var num1 = baseCoordinates.Longitude * (Math.PI / 180.0);
            var d2 = targetCoordinates.Latitude * (Math.PI / 180.0);
            var num2 = targetCoordinates.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var dist = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            return unitOfLength.ConvertFromMeters(dist);
        }
    }
    //class za spreminjanje merske enote
    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(0.001);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.00053996);
        public static UnitOfLength Miles = new UnitOfLength(0.0006213);
        public static UnitOfLength meters = new UnitOfLength(1);
        public static UnitOfLength yards = new UnitOfLength(1.09361334);
        public static UnitOfLength centimeters = new UnitOfLength(100);
        public static UnitOfLength feet = new UnitOfLength(3.2808);

        private readonly double _fromMetersFactor;

        private UnitOfLength(double fromMetersFactor)
        {
            _fromMetersFactor = fromMetersFactor;
        }

        public double ConvertFromMeters(double input)
        {
            return input * _fromMetersFactor;
        }
    }

}
