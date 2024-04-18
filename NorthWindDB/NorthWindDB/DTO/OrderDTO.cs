namespace NorthWindDB.DTO
{
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
        //public List<ProductDTO>? Products { get; set; }
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
        public List<ProductDTO>? Products { get; set; }
    }

    public class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}