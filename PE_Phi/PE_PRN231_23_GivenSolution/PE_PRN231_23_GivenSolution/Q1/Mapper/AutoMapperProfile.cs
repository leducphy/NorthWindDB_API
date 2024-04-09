using AutoMapper;
using Q1.DTO;
using Q1.Models;

namespace Q1.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Product, ProductDTO>().ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            //CreateMap<AddProductDTO, Product>().ForMember(dest => dest.Category, opt => opt.Ignore());
            //CreateMap<UpdateProductDTO, Product>();
            CreateMap<Movie, MovieDTO>().ForMember(des => des.DirectorName, src => src.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Title).ToList()));
        }

    }
}
