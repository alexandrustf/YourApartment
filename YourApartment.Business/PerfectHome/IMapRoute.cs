using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace YourApartment.Business
{
    public interface IMapRoute 
    {
        Task<Result<IEnumerable<int>>> GetTimeForRoutesAsync(double latOrigin, double lngOrigin,
            IEnumerable<Tuple<double, double>> destinations);
    }
}
