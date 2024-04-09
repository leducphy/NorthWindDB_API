namespace NorthWindDB.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
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
    }

    public class AddProductDTO
    {
        public AddProductDTO()
        {
        }

        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public String Category { get; set; }
    }

    public class UpdateProductDTO
    {
        public UpdateProductDTO()
        {
        }

        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public String Category { get; set; }
    }
}