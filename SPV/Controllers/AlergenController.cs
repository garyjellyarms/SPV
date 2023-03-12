using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPV.Utils;
using SPV.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlergenController : ControllerBase
    {
        private readonly AppDbContext db;

        public AlergenController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<AlergenController>
        [HttpGet]
        public IEnumerable<Alergen>? Get()
        {
            var alergens = db.Alergens.ToList();

            if (alergens == null || alergens.Count < 1) return null;

            return alergens;
        }

        // GET api/<AlergenController>/5
        [HttpGet("{id}")]
        public Alergen? Get(int id)
        {
            Alergen alergens = db.Alergens.FirstOrDefault(x => x.Id == id);

            if (alergens == null) return null;

            return alergens;
        }

        // POST api/<AlergenController>
        [HttpPost]
        public Alergen? Post([FromBody] Alergen newAlergen)
        {
            if (newAlergen == null || newAlergen.Id < 0) return null;

            var returnAlergen = db.Alergens.Add(newAlergen);
            db.SaveChanges();

            return returnAlergen.Entity;
        }

        // PUT api/<AlergenController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Alergen changeAlergen) ///(int id, [FromBody] string value)
        {
            if (id != changeAlergen.Id) return false;

            Alergen? oldAlergen = db.Alergens.FirstOrDefault(x => x.Id == changeAlergen.Id);

            if (oldAlergen == null) return false;

            oldAlergen.Snov = changeAlergen.Snov;
            oldAlergen.St_alergena = changeAlergen.St_alergena;

            db.SaveChanges();

            return true;
        }

        // DELETE api/<AlergenController>/5
        [HttpDelete("{id}")]
        public Alergen? Delete(int id)
        {
            if (id < 0) return null;

            Alergen? deletingAlergen = db.Alergens.FirstOrDefault(x => x.Id == id);

            if (deletingAlergen == null) return null;

            var deleted = db.Alergens.Remove(deletingAlergen);
            db.SaveChanges();

            return deleted.Entity;
        }
    }
}
