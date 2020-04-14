using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;

namespace YourApartment.Domain
{
    public sealed class ApplicationRole : IdentityRole<Guid>
    {
        private ApplicationRole(string name)
            : base(name)
        {
            NormalizedName = name;
        }

        public static Result<ApplicationRole> Create(string name)
        {
            return Result.Success(new ApplicationRole(name));
        }
    }
}
