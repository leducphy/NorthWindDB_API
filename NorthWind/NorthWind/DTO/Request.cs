using System.ComponentModel.DataAnnotations;

namespace NorthWind.DTO;


    public class UserAddRequest
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        [EmailAddress] public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class LoginRequestModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class CategoryAddRequest
    {
        public string Name { get; set; }
    }

    public class ProductAddRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
