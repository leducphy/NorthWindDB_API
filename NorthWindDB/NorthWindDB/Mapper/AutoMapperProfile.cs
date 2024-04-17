using AutoMapper;
using NorthWindDB.DTO;
using NorthWindDB.Models;
using NuGet.Protocol;

namespace NorthWindDB.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.CategoryName,
                    opt => opt.MapFrom(src => src.Category!.CategoryName))
                .ForMember(s => s.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier!.ContactName))
                .ForMember(total => total.TotalUnitSaled,
                    opt => opt.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity)))
                .ForAllMembers(x => x.Condition((_, target, sourceValue) => sourceValue != null));
            CreateMap<AddProductDTO, Product>().ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<Product, UpdateProductDTO>().ReverseMap().ForAllMembers(x =>
                x.Condition((source, target, sourceValue) => sourceValue != null));

            CreateMap<Category, CategoryDTO>()
                .ForMember(o => o.Picture, src => src.Ignore())
                .ForMember(x => x.Products , src => src.Ignore());
            CreateMap<Order, OrderDTO>()
                .ForMember(o => o.EmployeeName,
                    opt => opt.MapFrom(src => $"{src.Employee!.FirstName} {src.Employee.LastName}"))
                .ForMember(o => o.CustomerName, opt => opt.MapFrom(src => src.Customer.ContactName))
                .ForMember(o => o.ShipCompanyName,
                    opt => opt.MapFrom(src => src.ShipViaNavigation != null ? src.ShipViaNavigation.CompanyName : ""))
                .ForMember(o => o.TotalAmount,
                    opt => opt.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)))
                .ForMember(o => o.IsLateDate, opt => opt.MapFrom(src => src.ShippedDate > src.RequiredDate))
                ;
            CreateMap<OrderDetail, OrderDetailDTO>();
        }
    }
}