using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models.Users
{
    public class UserRegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
