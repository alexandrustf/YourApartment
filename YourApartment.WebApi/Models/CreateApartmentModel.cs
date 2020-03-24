using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.WebApi
{
    public class CreateApartmentModel
    {
        public string Title { get; set; }

        public IEnumerable<byte[]> ImagesBytes { get; set; }
    }
}
