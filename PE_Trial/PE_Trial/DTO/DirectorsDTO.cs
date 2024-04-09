using PE_Trial.Models;
using System.Text.Json.Serialization;

namespace PE_Trial.DTO
{
    public class DirectorsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string gender { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;
       
    }
}
