using Q1.Models;

namespace Q1.DTO;

public class MovieResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int? Year { get; set; }
    public string? Description { get; set; }
    public int DirectorId { get; set; }

    public string DirectorName { get; set; }
    public List<string> genres { get; set; }
}

public class ScheduleRequestDTO
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int RoomId { get; set; }
    public int? TimeSlotId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Note { get; set; }
}