using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SPV.Utils;
using SPV.Models;

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext db;
        PasswordManagement passwordManagement = new PasswordManagement();

        public UserController(AppDbContext db)
        {
            this.db = db;
        }

        //GET ALL
        [HttpGet]
        public IEnumerable<User>? Get()
        {
            var users = db.User.ToList();

            if (users == null || users.Count < 1)
            {
                return null;
            }


           return users;
        }

        //GET by username
        [HttpGet("{username}")]
        public User? GetUserName(string username)
        {
            User? user = db.User.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //GET by email
        [HttpGet("{email}")]
        public User? GetEmail(string email)
        {
            var user = db.User.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //POST
        [HttpPost]
        public User? Post([FromBody] User newUser)
        {
            if(newUser == null || newUser.Id < 0)
            {
                return null;
            }
            var returnUser = db.User.Add(newUser);
            db.SaveChanges();

            return returnUser.Entity;
        }

        //DELETE
        [HttpDelete("{id}")]
        public User? Delete(int id)
        {
            if(id < 0)
            {
                return null;
            }

            User? deleteUser = db.User.FirstOrDefault(x => x.Id == id);
            if(deleteUser == null )
            {
                return null;
            }

            var deletedUser = db.User.Remove(deleteUser);
            db.SaveChanges();

            return deletedUser.Entity;
        }

        //PUT
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] User changeUser)
        {
            if(id != changeUser.Id)
            {
                return false;
            }

            User? oldUser = db.User.FirstOrDefault(x => x.Id == id);    
            
            if(oldUser == null)
            {
                return false;
            }

            //treba je se hashirat geslo
            passwordManagement.HashPasword(changeUser);
            

            oldUser.Name = changeUser.Name;
            oldUser.Surname = changeUser.Surname;
            oldUser.Username = changeUser.Username;
            oldUser.Email = changeUser.Email;
            oldUser.Password = changeUser.Password;
            db.SaveChanges();

            return true;
        }

        
    }
}
