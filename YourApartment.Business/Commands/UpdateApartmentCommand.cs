using System;
using EnsureThat;

namespace YourApartment.Business
{
    public class UpdateApartmentCommand
    {
        public UpdateApartmentCommand(Guid id, string title)
        {
            EnsureArg.IsNotNull(title);
            EnsureArg.IsNotEmpty(id);
            Title = title;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}