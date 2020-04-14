using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IUserService
    {
        Task<AuthenticationToken> Authenticate(string username, string password);
        // IEnumerable<UserModel> GetAll();
        // UserModel GetById(int id);
        Task<Result> Create(CreateUserCommand command);
        // void Update(User user, string password = null);
        // void Delete(int id);
    }
}