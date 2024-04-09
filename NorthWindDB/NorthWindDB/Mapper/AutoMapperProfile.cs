using AutoMapper;
using NorthWindDB.DTO;
using NorthWindDB.Models;

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
                    opt => opt.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity) ));
            CreateMap<AddProductDTO, Product>().ForMember(dest => dest.Category, opt => opt.Ignore());
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            
        }
        
    }
}
