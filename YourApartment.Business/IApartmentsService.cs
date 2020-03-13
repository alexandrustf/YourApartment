using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IApartmentsService
    {
        Task<Result> Create(CreateAparmentCommand command);

        Task<PageModel<ApartmentModel>> GetAll(SieveQuery query);

        Task<Result<ApartmentDetailsModel>> GetDetailedById(GetSpecifiedApartmentQuery query);

        Task<Result> DeleteById(DeleteApartmentByIdCommand command);
    }
}
