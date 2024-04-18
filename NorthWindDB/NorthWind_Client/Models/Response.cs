using Newtonsoft.Json;

namespace NorthWind_Client.Models;

public class Response
{
    public class ProductResponse
    {
        public ProductResponse()
        {
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public int SupplierId { get; set; }
        public String SupplierName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int TotalUnitSaled { get; set; }
        public bool Discontinued { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
        //public List<ProductResponse>? Products { get; set; }
    }

    public class CategoryProductViewModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<ProductResponse> Products { get; set; }
        public int SelectedCategoryId { get; set; }
    }

    public class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }

    public class CustomerDTO
    {
        public string CustomerId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }

    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
        [JsonIgnore] public byte[]? Photo { get; set; }
        public string? Notes { get; set; }
        public int? ReportsTo { get; set; }
        [JsonIgnore] public string? PhotoPath { get; set; }
    }

    public class OrderDTO
    {
        public OrderDTO()
        {
        }

        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public string? ShipCompanyName { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public double? TotalAmount { get; set; }
        public int TotalItem { get; set; }
        public bool? IsLateDate { get; set; }
    }

    public class OrderDTO2
    {
        public OrderDTO2()
        {
        }

        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public string? ShipCompanyName { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public double? TotalAmount { get; set; }
        public int TotalItem { get; set; }
        public bool? IsLateDate { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}