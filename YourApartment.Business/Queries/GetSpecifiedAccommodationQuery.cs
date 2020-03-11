using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;

namespace YourApartment.Business
{
    public sealed class GetSpecifiedAccommodationQuery
    {
        public GetSpecifiedAccommodationQuery(Guid accommodationId)
        {
            EnsureArg.IsNotEmpty(accommodationId);
            AccommodationId = accommodationId;
        }
        public Guid AccommodationId { get; private set; }
    }
}
