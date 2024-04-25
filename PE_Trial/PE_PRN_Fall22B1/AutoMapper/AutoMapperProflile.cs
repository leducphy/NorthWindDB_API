using AutoMapper;
using PE_PRN_Fall22B1.DTO;
using PE_PRN_Fall22B1.Models;


namespace PE_PRN_Fall22B1.AutoMapper
{
    public class AutoMapperProflile : Profile
    {
       public AutoMapperProflile()
       {
           CreateMap<Director, DirectorDTO>()
               .ForMember(x => x.Gender, src => src.MapFrom(x => x.Male ? "Male" : "Female"))
               .ForMember(x => x.DobString , src => src.MapFrom(x=> x.Dob.ToString("MM/dd/yyyy")))
               .ForMember(x=>x.Movies , y=>y.MapFrom(x=>x.Movies))
               ;
           CreateMap<Movie, MovieDTO>()
               .ForMember(x => x.ProducerName, y => y.MapFrom(x => x.Producer.Name))
               .ForMember(x => x.DirectorName, y => y.MapFrom(x => x.Director.FullName));
       }
    }
}
