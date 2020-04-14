using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EnsureThat;
using YourApartment.Business;

namespace YourApartment.Business
{
    internal sealed class AuthService : IAuthService
    {
        private readonly IUserService userService;

        private readonly ITokenProvider tokenProvider;

        public AuthService(IUserService userService, ITokenProvider tokenProvider)
        {
            EnsureArg.IsNotNull(userService);
            EnsureArg.IsNotNull(tokenProvider);

            this.userService = userService;
            this.tokenProvider = tokenProvider;
        }

        public async Task<Result<AuthenticationToken>> Authenticate(AuthenticateUserCommand userCommand)
        {
            EnsureArg.IsNotNull(userCommand);

            var query = new GetUserByCredentialsQuery(userCommand.Email, userCommand.Password);

            return await userService.GetByCredentials(query)
                .OnSuccess(user => tokenProvider.GenerateTokenFor(user));
        }
    }
}