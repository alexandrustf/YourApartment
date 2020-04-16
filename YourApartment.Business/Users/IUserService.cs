using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IUserService
    {
        Task<Result<AuthenticationToken>> Authenticate(AuthenticateUserCommand command);
        // IEnumerable<UserModel> GetAll();
        // UserModel GetById(int id);
        Task<Result> Create(CreateUserCommand command);
        Task<Result> AddFavoriteApartment(AddToFavoriteCommand command);
        // void Update(User user, string password = null);
        // void Delete(int id);
    }
}