using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using SPV.Models;
using SPV.Utils;

namespace SPV.Controllers
{
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext db;
        public LocationController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("api/[controller]/Distance")]
        public double DistanceToRestaurant(double latitudeUser, double longitudeUser, double latitudeRest, double longitudeRest, string UnitofMessurement)
        {
            UnitOfLength unit;
            switch (UnitofMessurement)
            {
                case "Miles":
                    unit = UnitOfLength.Miles; 
                    break;
                case "NauticalMiles":
                    unit = UnitOfLength.NauticalMiles; 
                    break;
                case "Meters":
                    unit = UnitOfLength.meters; 
                    break;
                case "Yards":
                    unit = UnitOfLength.yards; 
                    break;
                case "Centimeters":
                    unit = UnitOfLength.centimeters; 
                    break;
                case "Feet":
                    unit = UnitOfLength.feet; 
                    break;
                default: 
                    unit = UnitOfLength.Kilometers;
                    break;
            }

            var distance = new Coordinates(latitudeUser, longitudeUser).DistanceTo(new Coordinates(latitudeRest, longitudeRest),unit);

            return distance;
        }
    }
}
