using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework.Repositories
{
    internal sealed class UsersReadRepository : BaseReadRepository<User>
    {
        public UsersReadRepository(YourApartmentContext context)
            : base(context)
        {
            
        }
    }
}
