using Q1.Models;

namespace Q1.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; } = string.Empty;
        public List<string> Genres { get; set; } 
    }
}
