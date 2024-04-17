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
    
    public  class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}