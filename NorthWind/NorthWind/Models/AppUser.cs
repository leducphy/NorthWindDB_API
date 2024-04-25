using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NorthWind.Models;

public class AppUser : IdentityUser
{
    [StringLength(50)]
    [Column("FullName")]
    public string FullName { get; set; }

    [StringLength(200)]
    [Column("Address")]
    public string? Adress { get; set; }

    [StringLength(100)]
    [Column("Phone")]
    public string? Phone { get; set; }
    [MaxLength(10)]
    public string? Gender { get; set; }
    public DateTime? DOB { get; set; }
    public string Address { get; set; }
}