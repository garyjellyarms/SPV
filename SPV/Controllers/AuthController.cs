using Microsoft.AspNetCore.Mvc;
using SPV.Models;
using SPV.Utils;


namespace SPV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext db;
        PasswordManagement passwordManagement = new PasswordManagement();

        public AuthController(AppDbContext dbGlobal)
        {
            this.db = dbGlobal;
        }
        [HttpPost(Name = "Login")]
        public Session Login([FromBody] User userInfo)
        {
            User userDb = db.User.FirstOrDefault(x => x.Email == userInfo.Email);
            if (userDb == null || userInfo.Password == null) { return new Session { DateTo = DateTime.MinValue, Id = -1, UserID = -1 }; }
            if (!passwordManagement.VerifyPassword(userInfo.Password, userDb))
            {
                return new Session { DateTo = DateTime.MinValue, Id = -1, UserID = -1 };
            }
            var savedSession = db.Sessions.Add(new Session { DateTo = DateTime.Now.AddHours(4.0), UserID = userDb.Id });
            db.SaveChanges();
            
            return savedSession.Entity;
        }

        [HttpPost(Name = "Register")]
        public Session Register([FromBody] User userInfo)
        {

            return new Session { };
        }

    }
}
