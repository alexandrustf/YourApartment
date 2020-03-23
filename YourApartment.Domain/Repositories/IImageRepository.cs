using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourApartment.Domain
{
    public interface IImageRepository
    {
        Task AddImage(Guid apartmentId, byte[] image);
        Task DeleteImage(Guid apartmentId);
        Task<IEnumerable<byte[]>> GetImagesForApartment(Guid apartmentId);
        Task SaveChanges();
    }
}