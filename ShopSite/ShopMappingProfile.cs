using AutoMapper;
using ShopSite.Entities;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite
{
    public class ShopMappingProfile : Profile
    {
        public ShopMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.Street, m => m.MapFrom(s => s.Adres.Street))
                .ForMember(u => u.City, m => m.MapFrom(s => s.Adres.City))
                .ForMember(u => u.Country, m => m.MapFrom(s => s.Adres.Country))
                .ForMember(u => u.PostalCode, m => m.MapFrom(s => s.Adres.PostalCode))
                .ForMember(u => u.HouseNumber, m => m.MapFrom(s => s.Adres.HouseNumber));

            CreateMap<NewUserDto, User>()
                .ForMember(r => r.Adres,
                c => c.MapFrom(dto => new Adres()
                {
                    City = dto.City,
                    Country = dto.Country,
                    PostalCode = dto.PostalCode,
                    HouseNumber = dto.HouseNumber,
                    Street = dto.Street
                }));
            CreateMap<NewProductDto, Product>();
          
                

        }
    }
}
