using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal sealed class ApartmentsReadRepository<T> : BaseReadRepository<T>
        where T : Entity
    {
        public ApartmentsReadRepository(YourApartmentContext context)
            : base(context)
        {
        }
    }
}
