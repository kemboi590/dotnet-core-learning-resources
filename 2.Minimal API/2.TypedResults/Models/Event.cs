namespace _2.TypedResults.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Capacity { get; set; }
    }
}
