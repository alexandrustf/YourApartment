using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace YourApartment.Business
{
    public interface ILocationsService
    {
        Task<Result> Create(CreateLocationCommand command);

        Task<IEnumerable<LocationModel>> GetAll();

        // Task<Result> DeleteById(DeleteLocationByIdCommand command);
        //
        // Task<Result> Update(UpdateLocationCommand command);
    }
}