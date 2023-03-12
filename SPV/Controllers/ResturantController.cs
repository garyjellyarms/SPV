using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        // GET: api/<ResturantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ResturantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ResturantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ResturantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPut("Ocena/{id}")]
        public bool PutOcena(int id, [FromBody] Restaurant changeRestaurant)
        {
            if (id != changeRestaurant.Id) return false;

            Restaurant? oldRestaurant = db.Restaurants.FirstOrDefault(x => x.Id == id);

            if (oldRestaurant == null) return false;


            //treba izracunat novo oceno
            int novaOcena = (oldRestaurant.Ocena + changeRestaurant.Ocena) / 2;


            oldRestaurant.Name = changeRestaurant.Name;
            oldRestaurant.X_coordinate = changeRestaurant.X_coordinate;
            oldRestaurant.Y_coordinate = changeRestaurant.Y_coordinate;
            oldRestaurant.OpeningTime = changeRestaurant.OpeningTime;
            oldRestaurant.Ocena = novaOcena;
            oldRestaurant.ClosingTime = changeRestaurant.ClosingTime;
            oldRestaurant.FoodList = changeRestaurant.FoodList;
            db.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
