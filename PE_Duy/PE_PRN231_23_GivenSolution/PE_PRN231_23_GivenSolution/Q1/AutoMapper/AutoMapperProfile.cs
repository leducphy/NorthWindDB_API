using AutoMapper;
using Q1.DTO;
using Q1.Models;

namespace Q1.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieResponseDTO>()
                .ForMember(dest => dest.DirectorName,
                    opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.genres,
                    opt => opt.MapFrom(src => src.Genres.Select(i => i.Title)));

            CreateMap<Schedule, ScheduleRequestDTO>().ReverseMap();
        }
    }
}
