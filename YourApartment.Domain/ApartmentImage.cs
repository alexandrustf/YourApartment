using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace YourApartment.Domain
{
    public class ApartmentImage
    {
        public string Id { get; private set; }
        public Guid ProductId { get; private set; }
        public byte[] Content { get; set; }

        public ApartmentImage(Guid apartmentId)
        {
            this.ProductId = apartmentId;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}