using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Models;

public class ProductSupplier
{
    
    public Guid ProductId { get; set; }
    public Guid SupplierId { get; set; }
    [DataType("money"), Column("Price")]
    
    public double UnitPrice { get; set; }
    public Product? Products { get; set; }
    public Supplier? Suppliers { get; set; }
}