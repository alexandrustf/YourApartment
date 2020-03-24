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

            Title = title;
            if (imageBytes == null)
            {
                imageBytes = new List<byte[]>();
            }
            ImageBytes = imageBytes;
        }

        public string Title { get; set; }

        public IEnumerable<byte[]> ImageBytes { get; set; }
    }
}
