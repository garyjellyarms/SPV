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
        // funkcija da lahko poves kazeri unite bos uporablo katero nato klice funkcijo za racunanje
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }
        // funkcija za racunanje razdallje od uporabnika do restavracije
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromKilometers(dist);
        }
    }
    //class za spreminjanje merske enote
    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.539956803);
        public static UnitOfLength Miles = new UnitOfLength(0.621371192);
        public static UnitOfLength meters = new UnitOfLength(1000);
        public static UnitOfLength yards = new UnitOfLength(1093.6133);
        public static UnitOfLength centimeters = new UnitOfLength(100000);
        public static UnitOfLength feet = new UnitOfLength(3280.8399);

        private readonly double _fromKilometersFactor;

        private UnitOfLength(double fromKilometerFactor)
        {
            _fromKilometersFactor = fromKilometerFactor;
        }

        public double ConvertFromKilometers(double input)
        {
            return input * _fromKilometersFactor;
        }
    }

}
