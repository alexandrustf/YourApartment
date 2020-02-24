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

        Task<Maybe<AccommodationModel>> GetById(GetAccommodationById query);

        Task<Result> DeleteById(DeleteAccommodationByIdCommand command);
    }
}
