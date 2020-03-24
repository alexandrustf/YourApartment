using EnsureThat;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class CreateApartmentCommand
    {
        public CreateApartmentCommand(string title, IEnumerable<byte[]> imageBytes)
        {
            EnsureArg.IsNotNullOrEmpty(title);
            EnsureArg.IsNotNull(imageBytes);

            Title = title;
            ImageBytes = imageBytes;
        }

        public string Title { get; set; }

        public IEnumerable<byte[]> ImageBytes { get; set; }
    }
}
