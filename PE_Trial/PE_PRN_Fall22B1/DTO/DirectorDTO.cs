using PE_PRN_Fall22B1.Models;

namespace PE_PRN_Fall22B1.DTO;

public class DirectorDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public string DobString { get; set; }
    public string Nationality { get; set; } = null!;
    public string Description { get; set; } = null!;

    public List<MovieDTO>? Movies { get; set; }
}

public class DirectorAddRequest
{
    public string FullName { get; set; } = null!;
    public bool Male { get; set; }
    public DateTime Dob { get; set; }
    public string Nationality { get; set; } = null!;
    public string Description { get; set; } = null!;
}