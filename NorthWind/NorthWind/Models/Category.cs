namespace NorthWind.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Navigation property
    public ICollection<Product> Products { get; set; }
}