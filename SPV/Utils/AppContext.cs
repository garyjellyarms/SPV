using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SPV.Models;
namespace SVP_BackEnd.Utils
{
    public class AppContext : DbContext
    {
        public AppContext() : base()
        {

        }
        public DbSet<User> Students { get; set; }
        public DbSet<Session> Grades { get; set; }
    }
}
