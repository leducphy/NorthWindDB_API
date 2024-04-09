using AutoMapper;
using PE_Trial.DTO;
using PE_Trial.Models;

namespace PE_Trial.AutoMapper
{
    public class AutoMapperProflile : Profile
    {
       public AutoMapperProflile() {
            CreateMap<Director, DirectorsDTO>().ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.Male ? "Male" : "Female"));
        }
    }
}
