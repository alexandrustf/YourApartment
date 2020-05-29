using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public class GetFavoriteApartmentsForUserQuery
    {
        public GetFavoriteApartmentsForUserQuery(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}
