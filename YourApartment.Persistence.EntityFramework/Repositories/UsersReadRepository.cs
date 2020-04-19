using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework.Repositories
{
    internal sealed class UsersReadRepository : BaseReadRepository<User>
    {
        public UsersReadRepository(YourApartmentContext context)
            : base(context)
        {
            
        }

        protected override IQueryable<User> DecorateEntities(IQueryable<User> entities)
        {
            return entities.Include(p => p.FavoriteApartments);
        }

    }
}
