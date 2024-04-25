using AutoMapper;
using PE_Trial.DTO;
using PE_Trial.Models;


namespace PE_Trial.AutoMapper
{
    public class AutoMapperProflile : Profile
    {
       public AutoMapperProflile() {
             CreateMap<Order, OrderDTO>()
                 .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer!.ContactName ))
                 .ForMember(des => des.EmployeeName , src => src.MapFrom(x => $"{x.Employee!.FirstName} {x.Employee.LastName}"))
                 .ForMember(des => des.EmployeeDepartmentName , src => src.MapFrom(x=> x.Employee!.Department!.DepartmentName))
                 ;
        }
    }
}
