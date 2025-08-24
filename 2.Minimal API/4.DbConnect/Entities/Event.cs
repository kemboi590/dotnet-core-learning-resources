namespace _4.DbConnect.Entities
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Capacity { get; set; }

        public string? PromoCode { get; set; }
    }
}
