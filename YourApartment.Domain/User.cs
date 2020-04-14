using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;

namespace YourApartment.Domain
{
    public sealed class User : IdentityUser<Guid>
    {
        private ICollection<IdentityUserRole<Guid>> roles = new List<IdentityUserRole<Guid>>();

        private User(string email)
            : base(email)
        {
            Email = email;
        }

        public static string RolesField => nameof(User.roles);

        public Maybe<IdentityUserRole<Guid>> Role => this.roles.FirstOrDefault();

        public static Result<User> Create(string email)
        {
            return Result.Success<User>(new User(email));
        }
    }
}
