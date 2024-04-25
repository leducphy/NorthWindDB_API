using System;

namespace NorthWind_Client.Models;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
}

class CategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

class LoginResponseModel
{
    public string Token { get; set; }
    public string Role { get; set; }
    public Guid UserId { get; set; }
}