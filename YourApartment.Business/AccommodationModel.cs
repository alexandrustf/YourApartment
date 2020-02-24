using System;
using System.Collections.Generic;
using System.Text;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public sealed class AccommodationModel
    {
        public AccommodationModel(Apartment apartment)
        {
            Title = apartment.Title;
        }

        public string Title { get; private set; }
    }
}
