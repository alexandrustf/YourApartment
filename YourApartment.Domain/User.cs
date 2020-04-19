using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpFunctionalExtensions;
using EnsureThat;

namespace YourApartment.Domain
{
    public class User : Entity
    {
        private readonly ICollection<UserApartment> favoriteApartments = new List<UserApartment>();

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

            Role = AppRole.User;
        }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Role { get; set; }
        public string PhoneNumber { get;  set; }

        public byte[] PasswordHash { get;  set; }
        public byte[] PasswordSalt { get;  set; }

        public IEnumerable<UserApartment> FavoriteApartments => favoriteApartments.AsEnumerable();

        public static Result<User> Create(string Name, string Email, string phoneNumber, byte[] passwordHash, byte[] passwordSalt)
        {
            EnsureArg.IsNotEmpty(Name);
            EnsureArg.IsNotEmpty(Email);

            return Result.Success<User>(new User(Name, Email,phoneNumber, passwordHash, passwordSalt));
        }

        public Result AddToFavorite(Apartment apartment)
        {
            EnsureArg.IsNotNull(apartment);

            var duplicate = favoriteApartments.FirstOrDefault(p => p.Apartment == apartment && p.User == this);
            if (duplicate == null)
            {
                favoriteApartments.Add(new UserApartment(this, apartment));
                return Result.Success("Apartment added In favorite list");
            }
            return Result.Failure("Apartment Already In favorite list");
        }

    }
}
