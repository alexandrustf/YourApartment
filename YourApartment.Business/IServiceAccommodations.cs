using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IServiceAccommodations
    {
        Task<Result> Create(CreateAccommodationCommand command);

        Task<IEnumerable<AccommodationModel>> GetAll(GetAccommodationsQuery query);

        Task<Result<AccommodationDetailsModel>> GetSpecifiedAccommodation(GetSpecifiedAccommodationQuery query);
    }
}
