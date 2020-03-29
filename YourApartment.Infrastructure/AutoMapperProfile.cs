using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YourApartment.Business;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Apartment, ApartmentModel>()
                .ForMember(p => p.Images, map => map.MapFrom(s => GetImagesForApartment(s.Id).Result));
            CreateMap<Apartment, ApartmentDetailsModel>()
                .ReverseMap();
        }

        private static async Task<IEnumerable<byte[]>> GetImagesForApartment(Guid apartmentId)
        {
            string[] fileEntries = Directory.GetFiles(Path.Combine("..\\Images", apartmentId.ToString())); //TODO should not hardcode string
            var images = new List<byte[]>();
            foreach (var fileEntry in fileEntries)
            {
                images.Add(await File.ReadAllBytesAsync(fileEntry));
            }
            return images;

        }
    }
}
