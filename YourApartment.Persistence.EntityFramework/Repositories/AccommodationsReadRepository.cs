using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal sealed class AccommodationsReadRepository<T> : BaseReadRepository<T>
        where T : Entity
    {
        public AccommodationsReadRepository(YourApartmentContext context)
            : base(context)
        {
        }
    }
}
