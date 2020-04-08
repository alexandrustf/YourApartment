using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal sealed class ApartmentsReadRepository : BaseReadRepository<Apartment>
    {
        public ApartmentsReadRepository(YourApartmentContext context)
            : base(context)
        {
        }

        protected override IQueryable<Apartment> DecorateEntities(IQueryable<Apartment> entities)
        {
            return entities.Include(p => p.Location);
        }
    }
}
