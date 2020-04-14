using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace YourApartment.Business
{
    public interface IAuthService
    {
        Task<Result<AuthenticationToken>> Authenticate(AuthenticateUserCommand userCommand);
    }
}
