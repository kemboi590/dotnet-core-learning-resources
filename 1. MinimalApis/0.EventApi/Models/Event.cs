namespace _0.EventApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Capacity { get; set; }
    }
}
