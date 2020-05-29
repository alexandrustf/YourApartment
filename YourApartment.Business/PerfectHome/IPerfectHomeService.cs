using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace YourApartment.Business
{
    public interface IPerfectHomeService
    {
        Task<Result<IEnumerable<ApartmentModel>>> PerfectApartments(PerfectHomeQuery perfectHomeQuery);
    }
}
