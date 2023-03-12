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
        public Group Group;

        public GroupController(AppDbContext db)
        {
            this.db = db;

            Group = new Group();

        }

        // GET: api/<GroupController>
        [HttpGet]
        
        public async Task<ActionResult<List<Group>>> Get()
        {
            var groupList = Group.Groups;


            if (groupList != null)
            {
                return Ok(groupList);
            }
            else
                return BadRequest();

        }


        // GET api/<GroupController>/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> Get(Guid guid)
        {
            var group = Group.Groups.Where(g => g.Guid == guid).FirstOrDefault();

            if (group != null)
            {
                return Ok(group);
            }
            else
                return BadRequest();

        }

        // POST api/<GroupController>
        [HttpPost]
        public async Task<ActionResult<List<Group>>> Post([FromBody] Group newGroup)
        {
            if(newGroup == null)
            {
                return BadRequest();
            }
            else
                Group.Groups.Add(newGroup);
                Group.CreateNewGroup();
            return Ok();


        }



        [HttpPut]
        public async Task<ActionResult<List<Group>>> Put([FromBody] Group newGroup)
        {

            var groupToUpdate = Group.Groups.Where(g => g.Guid == newGroup.Guid).FirstOrDefault();

            if (groupToUpdate == null)
            {
                return BadRequest();
            }
            else

                return Ok(groupToUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Delegate>>> Delete(Guid guid)
        {
            var groupToDelete = Group.Groups.Where(g => g.Guid == guid).FirstOrDefault();

            if (groupToDelete != null)
            {
                Group.Groups.Remove(groupToDelete);
                return Ok(groupToDelete);
            }
            else
                return BadRequest();

        }



    }
}
