using Microsoft.AspNetCore.Mvc;
using SPV.Utils;
using SPV.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext db;

        public FoodController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<Food>? Get()
        {
            var foods = db.Foods.ToList();

            if (foods == null || foods.Count < 1) return null;

            return foods;
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public Food? Get(int id)
        {
            Food food = db.Foods.FirstOrDefault(x => x.Id == id);

            if (food == null) return null;

            return food;
        }

        // POST api/<FoodController>
        [HttpPost]
        public Food? Post([FromBody] Food newFood)
        {
            if (newFood == null || newFood.Id < 0) return null;

            var returnFood = db.Foods.Add(newFood);
            db.SaveChanges();

            return returnFood.Entity;
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Food changeFood) ///(int id, [FromBody] string value)
        {
            if(id != changeFood.Id) return false;

            Food? oldFood = db.Foods.FirstOrDefault(x => x.Id == changeFood.Id);

            if (oldFood == null) return false;

            oldFood.Picture = changeFood.Picture;
            oldFood.Name = changeFood.Name;

            db.SaveChanges();

            return true;
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public Food? Delete(int id)
        {
            if (id < 0 ) return null;

            Food? deletingFood = db.Foods.FirstOrDefault(x =>x.Id == id);

            if(deletingFood == null) return null;

            var deleted = db.Foods.Remove(deletingFood);
            db.SaveChanges();
            
            return deleted.Entity;
        }
    }
}
