using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPV.Utils;
using SPV.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext db;

        public SessionController(AppDbContext db)
        { 
            this.db = db;
        }
        //API

        //GET

        //GET ID

        //DELETE

        //POST


    }
}
