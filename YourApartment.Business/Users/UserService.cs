using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.AspNetCore.Identity;
using YourApartment.Common;
using YourApartment.Domain;

namespace YourApartment.Business
{
    internal sealed class UserService : IUserService
    {
        private const int GeneratedPasswordLength = 10;

        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            EnsureArg.IsNotNull(userManager);
            this.userManager = userManager;
        }

        public async Task<Result> Create(string email, string password, string role)
        {
            return await User.Create(email)
                .Map(u => userManager.CreateAsync(u, password))
                .Ensure(createResult => createResult.Succeeded, "User creation failed")
                .Map(async _ =>
                {
                    var user = await userManager.FindByEmailAsync(email);
                    return await userManager.AddToRoleAsync(user, role);
                })
                .Ensure(assignRoleResult => assignRoleResult.Succeeded, "User creation failed");
        }

        public async Task<Result<User>> GetByCredentials(GetUserByCredentialsQuery query)
        {
            EnsureArg.IsNotNull(query);

            var userResult = await userManager.FindByEmailAsync(query.Email).ToMaybe()
                .ToResult("Invalid Credentials!");
            return await userResult.Map(user => userManager.CheckPasswordAsync(user, query.Password))
                .Ensure(passwordIsValid => passwordIsValid, "Invalid Credentials!")
                .OnSuccess(_ => userResult);
        }

        public string GetRole(User user)
        {
            return userManager.GetRolesAsync(user).Result.FirstOrDefault();
        }
    }
}
