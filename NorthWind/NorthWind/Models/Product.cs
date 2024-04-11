using System.ComponentModel.DataAnnotations;

namespace NorthWind.Models;

public class Product
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Foreign Key
    public Guid CategoryId { get; set; }
    // Navigation property
    public Category Category { get; set; }
    public ICollection<ProductSupplier> ProductSuppliers { get; set; }
}
