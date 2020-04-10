using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class GetApartmentById
    {
        public GetApartmentById(Guid id)
        {
            EnsureArg.IsNotEmpty(id);
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
