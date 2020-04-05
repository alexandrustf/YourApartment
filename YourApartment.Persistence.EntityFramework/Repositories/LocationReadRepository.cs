using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework.Repositories
{
    internal sealed class LocationReadRepository : BaseReadRepository<Location>
    {
        public LocationReadRepository(YourApartmentContext context)
            : base(context)
        {
        }

        protected override IQueryable<Location> DecorateEntities(IQueryable<Location> entities)
        {
            return entities.Include(p => p.AdressLocation);
        }
    }
}
