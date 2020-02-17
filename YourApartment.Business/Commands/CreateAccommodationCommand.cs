using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class CreateAccommodationCommand
    {
        public CreateAccommodationCommand(string title)
        {
            EnsureArg.IsNotNullOrEmpty(title);
            Title = title;
        }

        public string Title { get; set; }
    }
}
