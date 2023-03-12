using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPV.Models;
using SPV.Utils;

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly AppDbContext db;

        public GroupController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<GroupController>
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            var groups = db.Groups.ToList();

            if (groups == null || groups.Count < 1) return null;

            return groups;
        }

        // GET api/<GroupController>/5
        [HttpGet("{guid}")]
        public Group Get(Guid guid)
        {
            Group group = db.Groups.FirstOrDefault(g => g.Guid == guid);

            if (group == null) return null;

            return group;
        }

        // POST api/<GroupController>
        [HttpPost]
        public Group Post([FromBody] Group newGroup)
        {
            if (newGroup == null) return null;

            var group = db.Groups.Add(newGroup);
            db.SaveChanges();

            return group.Entity;
        }

        // PUT api/<GroupController>/5
        [HttpPut("{guid}")]
        public bool Put(Guid guid, [FromBody] Group changeGroup)
        {
            if (guid != changeGroup.Guid) return false;

            Group oldGroup = db.Groups.FirstOrDefault(x => x.Guid == guid);

            if (oldGroup == null) return false;

            oldGroup.Created = changeGroup.Created;
            oldGroup.Users = changeGroup.Users.ToList();
            oldGroup.Foods = changeGroup.Foods.ToList();
            oldGroup.FoodRating = changeGroup.FoodRating;
            db.SaveChanges();

            return true;
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{guid}")]
        public Group Delete(Guid guid)
        {
            if (guid == null) return null;

            Group deletingGroup = db.Groups.FirstOrDefault(x => x.Guid == guid);

            if (deletingGroup == null) return null;

            var deleted = db.Groups.Remove(deletingGroup);
            db.SaveChanges();

            return deleted.Entity;
        }
    }

}
