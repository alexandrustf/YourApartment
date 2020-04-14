using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IUserService
    {
        Task<Result<User>> GetByCredentials(GetUserByCredentialsQuery query);

        Task<Result> Create(string email, string password, string role);
    }
}
