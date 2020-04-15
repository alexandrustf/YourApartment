using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface ITokenProvider
    {
        AuthenticationToken CreateTokenForUser(User user);
    }
}
