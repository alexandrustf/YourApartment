using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public interface ITokenProvider
    {
        AuthenticationToken CreateTokenForUser(Guid id, string email, string name);
    }
}
