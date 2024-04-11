namespace NorthWind.Models
{
    public class Supplier
    {
        public Guid SupplierID { get; set; }
        public string SupplierName { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}