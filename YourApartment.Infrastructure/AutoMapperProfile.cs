using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using YourApartment.Business;
using YourApartment.Domain;

namespace YourApartment.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Apartment, AccommodationModel>()
                .ReverseMap();
            CreateMap<Apartment, AccommodationDetailsModel>()
                .ReverseMap();
        }
    }
}
