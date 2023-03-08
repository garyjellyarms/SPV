﻿namespace SPV.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password {get;set;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? Created { get; set; }
        public string? Salt { get; set; }
        public User() { }

    }

}
