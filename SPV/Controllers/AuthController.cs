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
        [HttpPost]
        [Route("api/[controller]/login")]
        public Session Login([FromBody] User userInfo)
        {
            User userDb = db.User.FirstOrDefault(x => x.Email == userInfo.Email);
            if (userDb == null || userInfo.Password == null) { return new Session { Error = "Wrong body parameters" }; }
            if (!passwordManagement.VerifyPassword(userInfo.Password, userDb))
            {
                return new Session { Error="Wrong password"};
            }
            var savedSession = db.Sessions.FirstOrDefault(x => x.UserID == userDb.Id);//db.Sessions.Add(new Session { DateTo = DateTime.Now.AddHours(4.0), UserID = userDb.Id, Error = "" });
            if (savedSession == null)
            {
                var newSession = db.Sessions.Add(new Session { DateTo = DateTime.Now.AddHours(4.0), UserID = userDb.Id, Error = "" });
                db.SaveChanges();
                return newSession.Entity;

            }
            else
            {
                savedSession.DateTo = DateTime.Now.AddHours(4.0); 
                db.SaveChanges();
                return savedSession;
            }
            
            
        }

        [HttpPost]
        [Route("api/[controller]/register")]
        public Session Register([FromBody] User userInfo)
        {
            var userCheck = db.User.FirstOrDefault(x => x.Username == userInfo.Username || x.Email == userInfo.Email);
            if (userCheck != null) { return new Session { Error = "User already exists" }; } 
            User newUser = new User 
            {
                Username = userInfo.Username,
                Surname = userInfo.Surname,
                Email=userInfo.Email,
                Created=userInfo.Created,
                Name= userInfo.Name,
                Password=userInfo.Password
            };
            passwordManagement.HashPasword(newUser);
            var retUser = db.User.Add(newUser);
            db.SaveChanges();
            var session = new Session { DateTo = DateTime.Now.AddHours(4.0), UserID = retUser.Entity.Id, Error = "" };
            db.Sessions.Add(session);
            db.SaveChanges();
            return session;

        }

    }
}
