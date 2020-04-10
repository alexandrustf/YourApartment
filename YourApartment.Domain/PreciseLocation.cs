using System.Collections.Generic;
using CSharpFunctionalExtensions;
using EnsureThat;

namespace YourApartment.Domain
{
    public class PreciseLocation : ValueObject
    {
        private PreciseLocation()
        {
            
        }
        public PreciseLocation(string preciseLocation)
        {
            this.PreciseAdress = preciseLocation;
        }

        public string PreciseAdress { get; private set; }

        public static Result<PreciseLocation> Create(string preciseLocation)
        {
            EnsureArg.IsNotEmpty(preciseLocation);

            return Result.Success<PreciseLocation>(new PreciseLocation(preciseLocation)); 
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.PreciseAdress;
        }
    }
}