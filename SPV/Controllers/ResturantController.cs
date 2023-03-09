using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPV.Utils;
using SPV.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SPV.Controllers
{
    public class ResturantController : Controller
    {
        private readonly AppDbContext db;

        public ResturantController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<ResturantController>
        [HttpGet]
        public IEnumerable<Restaurant>? Get()
        {
            var restaurants = db.Restaurants.ToList();

            if (restaurants == null || restaurants.Count < 1) return null;

            return restaurants;
        }

        // GET: api/<RestaurantController>/5
        [HttpGet("{id}")]
        public Restaurant? Get(int id)
        {
            Restaurant? restaurant = db.Restaurants.FirstOrDefault(x => x.Id == id);

            if(restaurant == null) return null;

            return restaurant;
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public Restaurant? Post([FromBody] Restaurant newRestaurant)
        {
            if(newRestaurant == null || newRestaurant.Id < 0) return null;

            var returnRestaurant = db.Restaurants.Add(newRestaurant);
            db.SaveChanges();

            return returnRestaurant.Entity;
        }

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Restaurant changeRestaurant)
        {
            if(id != changeRestaurant.Id) return false;

            Restaurant? oldRestaurant = db.Restaurants.FirstOrDefault(x => x.Id == id);

            if (oldRestaurant == null) return false;

            oldRestaurant.Name = changeRestaurant.Name;
            oldRestaurant.X_coordinate = changeRestaurant.X_coordinate;
            oldRestaurant.Y_coordinate = changeRestaurant.Y_coordinate;
            oldRestaurant.OpeningTime = changeRestaurant.OpeningTime;
            oldRestaurant.ClosingTime = changeRestaurant.ClosingTime;
            oldRestaurant.FoodList = changeRestaurant.FoodList;
            db.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public Restaurant? Delete(int id)
        {
            if(id < 0) return null;

            Restaurant? deletingRestaurant = db.Restaurants.FirstOrDefault(x => x.Id == id);

            if (deletingRestaurant == null) return null;

            var deleted = db.Restaurants.Remove(deletingRestaurant);
            db.SaveChanges();

            return deleted.Entity;
        }
    }
}
