using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using EnsureThat;

namespace YourApartment.Domain
{
    public class User : Entity
    {
        private User()
        {
            
        }

        public User(string name, string email, string phoneNumber, byte[] passwordHash, byte[] passwordSalt)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }

        public byte[] PasswordHash { get;  set; }
        public byte[] PasswordSalt { get;  set; }

        public static Result<User> Create(string Name, string Email, string phoneNumber, byte[] passwordHash, byte[] passwordSalt)
        {
            EnsureArg.IsNotEmpty(Name);
            EnsureArg.IsNotEmpty(Email);

            return Result.Success<User>(new User(Name, Email,phoneNumber, passwordHash, passwordSalt));
        }
    }
}
