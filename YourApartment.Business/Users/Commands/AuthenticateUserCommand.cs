using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class AuthenticateUserCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public AuthenticateUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
