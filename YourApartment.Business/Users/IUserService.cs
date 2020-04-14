using System.Collections.Generic;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}