using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;

namespace YourApartment.Business
{
    public sealed class AuthenticateUserCommand
    {
        public AuthenticateUserCommand(string email, string password)
        {
            EnsureArg.IsNotNullOrEmpty(email);
            EnsureArg.IsNotNullOrEmpty(password);

            Email = email;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }
}
