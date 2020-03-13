using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class DeleteApartmentByIdCommand
    {
        public DeleteApartmentByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
