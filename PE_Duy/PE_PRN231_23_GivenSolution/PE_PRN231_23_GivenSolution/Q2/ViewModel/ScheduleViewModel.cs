namespace Q2.ViewModel;

public class ScheduleViewModel
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int RoomId { get; set; }
    public int? TimeSlotId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Note { get; set; }
}

public class ScheduleResponseViewModel
{
    public int Id { get; set; }
    public string MovieName { get; set; }
    public string RoomName { get; set; }
    public int? TimeSlotId { get; set; }
    public TimeSpan StartDate { get; set; }
    public TimeSpan EndDate { get; set; }
    public string? Note { get; set; }
}

public class RoomViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? Capacity { get; set; }
}

public class TimeSlotViewModel
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class MovieViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}