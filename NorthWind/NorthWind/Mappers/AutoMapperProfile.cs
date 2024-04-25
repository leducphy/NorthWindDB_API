using AutoMapper;

using System.Threading.Channels;
using NorthWind.DTO;
using NorthWind.Models;

namespace NorthWind.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryAddRequest>().ReverseMap().ForMember(x => x.Name , src => src.MapFrom(x=>x.Name));
            CreateMap<Product, ProductResponse>()
                .ForMember(x => x.CategoryName, src => src.MapFrom(x => x.Category.Name));
            CreateMap<Product, ProductAddRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();
        }

    }
}
