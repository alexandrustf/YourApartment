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
            CreateMap<Apartment, ApartmentModel>()
                .ReverseMap();
            CreateMap<Apartment, ApartmentDetailsModel>()
                .ReverseMap();
        }
    }
}
