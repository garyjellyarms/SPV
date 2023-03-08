using System.ComponentModel;

namespace SPV.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public DateTime DateTo { get; set; }
        public Session()
        {}
    }
}
