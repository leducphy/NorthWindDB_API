using System;

namespace NorthWind_Client.Models;

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class ProductUpdateRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}