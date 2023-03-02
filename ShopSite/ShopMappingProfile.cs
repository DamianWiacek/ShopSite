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
                .ForMember(u => u.HouseNumber, m => m.MapFrom(s => s.Adres.HouseNumber))
                .ForMember(u => u.Id, m => m.Ignore());
                

            CreateMap<NewUserDto, User>()
                .ForMember(r => r.Adres,
                c => c.MapFrom(dto => new Adres()
                {
                    City = dto.City,
                    Country = dto.Country,
                    PostalCode = dto.PostalCode,
                    HouseNumber = dto.HouseNumber,
                    Street = dto.Street
                }))
                .ForMember(u => u.Id, m => m.Ignore())
                .ForMember(u => u.PasswordHash, m => m.Ignore())
                .ForMember(u => u.AdresId, m => m.Ignore())
                .ForMember(u => u.RoleId, m => m.Ignore())
                .ForMember(u => u.Role, m => m.Ignore());

            CreateMap<NewProductDto, Product>()
                .ForMember(u => u.Id, m => m.Ignore());

            CreateMap<OrderDetailsDto, OrderDetails>()
                .ForMember(u => u.Id, m => m.Ignore())
                .ForMember(u => u.Product, m => m.Ignore())
                .ForMember(u => u.Order, m => m.Ignore());

            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<Order,OrderDto>()
                .ForMember(u => u.TotalPrice, m => m.Ignore());







        }
    }
}
