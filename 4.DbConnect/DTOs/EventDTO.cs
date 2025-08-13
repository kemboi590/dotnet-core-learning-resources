using _4.DbConnect.Entities;

namespace _4.DbConnect.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Capacity { get; set; }

        public EventDTO() { }
        public EventDTO(Event @event) =>
            (Id, Title, Description, StartTime, EndTime, Capacity) = (@event.Id, @event.Title, @event.Description,@event.StartTime, @event.EndTime, @event.Capacity); 
        
    }
}
