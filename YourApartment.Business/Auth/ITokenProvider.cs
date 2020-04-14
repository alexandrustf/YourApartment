using CSharpFunctionalExtensions;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface ITokenProvider
    {
        Result<AuthenticationToken> GenerateTokenFor(User user);
    }
}