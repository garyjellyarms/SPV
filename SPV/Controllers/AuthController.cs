using Microsoft.AspNetCore.Mvc;
using SVP_BackEnd.Models;

namespace SVP_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost(Name = "Login")]
        public Session Login([FromBody] User value)
        {

            return new Session { };
        }

        [HttpPost(Name = "Register")]
        public Session Register([FromBody] User value)
        {

            return new Session { };
        }

    }
}
