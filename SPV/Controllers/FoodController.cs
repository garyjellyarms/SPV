using Microsoft.AspNetCore.Mvc;
using SPV.Utils;
using SPV.Models;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //To bi blo bolsi pod OrderController samo nismo tak dalec prisli
        // POST api/<FoodController>/OdstraniSestavine
        [HttpPost]
        [Route("OdstraniSestavine")]
        public Food? Post(int id, [FromBody] string sestavineZaOdstranit)
        {
            List<string> templist = new List<string>();
            string[] words = sestavineZaOdstranit.Split(',');

            foreach (var word in words)
            {
                templist.Add(word);
            }

            var food = db.Foods.FirstOrDefault(x=> x.Id == id);
            List<string> templist2 = new List<string>();
            if (food != null)
            {
                string[] words2 = food.OpisHrane.Split(',');
                foreach (var word in words2)
                {
                    templist2.Add(word);
                }
                foreach (var ingrediant in templist2)
                {
                    if (templist.Contains(ingrediant))
                    {
                        templist2.Remove(ingrediant);
                    }
                }
                food.OpisHrane = "";
                if (templist2 != null)
                {

                    foreach (var ingrediant in templist2)
                    {
                        food.OpisHrane += ingrediant + ",";
                    }

                    food.OpisHrane = food.OpisHrane.Remove(food.OpisHrane.Length - 1, 1);
                }

                var returnFood = db.Foods.Add(food);
                db.SaveChanges();
                return returnFood.Entity;
            }
            

            return null;
        }

        //To bi blo bolsi pod OrderController samo nismo tak dalec prisli
        // POST api/<FoodController>/OdstraniSestavine
        [HttpPost]
        [Route("OdstraniSestavine")]
        public Food? Post(int id, [FromBody] string sestavineZaOdstranit)
        {
            List<string> templist = new List<string>();
            string[] words = sestavineZaOdstranit.Split(',');

            foreach (var word in words)
            {
                templist.Add(word);
            }

            var food = db.Foods.FirstOrDefault(x=> x.Id == id);
            List<string> templist2 = new List<string>();
            if (food != null)
            {
                string[] words2 = food.OpisHrane.Split(',');
                foreach (var word in words2)
                {
                    templist2.Add(word);
                }
                foreach (var ingrediant in templist2)
                {
                    if (templist.Contains(ingrediant))
                    {
                        templist2.Remove(ingrediant);
                    }
                }
                food.OpisHrane = "";
                if (templist2 != null)
                {

                    foreach (var ingrediant in templist2)
                    {
                        food.OpisHrane += ingrediant + ",";
                    }

                    food.OpisHrane = food.OpisHrane.Remove(food.OpisHrane.Length - 1, 1);
                }

                var returnFood = db.Foods.Add(food);
                db.SaveChanges();
                return returnFood.Entity;
            }
            

            return null;
        }

        //To bi blo bolsi pod OrderController samo nismo tak dalec prisli
        // POST api/<FoodController>/OdstraniSestavine
        [HttpPost]
        [Route("OdstraniSestavine")]
        public Food? Post(int id, [FromBody] string sestavineZaOdstranit)
        {
            List<string> templist = new List<string>();
            string[] words = sestavineZaOdstranit.Split(',');

            foreach (var word in words)
            {
                templist.Add(word);
            }

            var food = db.Foods.FirstOrDefault(x=> x.Id == id);
            List<string> templist2 = new List<string>();
            if (food != null)
            {
                string[] words2 = food.OpisHrane.Split(',');
                foreach (var word in words2)
                {
                    templist2.Add(word);
                }
                foreach (var ingrediant in templist2)
                {
                    if (templist.Contains(ingrediant))
                    {
                        templist2.Remove(ingrediant);
                    }
                }
                food.OpisHrane = "";
                if (templist2 != null)
                {

                    foreach (var ingrediant in templist2)
                    {
                        food.OpisHrane += ingrediant + ",";
                    }

                    food.OpisHrane = food.OpisHrane.Remove(food.OpisHrane.Length - 1, 1);
                }

                var returnFood = db.Foods.Add(food);
                db.SaveChanges();
                return returnFood.Entity;
            }
            

            return null;
        }
    }
}
