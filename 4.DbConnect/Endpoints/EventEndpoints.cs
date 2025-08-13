using _4.DbConnect.Data;
using _4.DbConnect.DTOs;
using _4.DbConnect.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4.DbConnect.Endpoints
{
    public static class EventEndpoints
    {
        public static RouteGroupBuilder MapEventEndpoint(this IEndpointRouteBuilder routes)
        {
            //MapGroup API
            var events = routes.MapGroup("/events");

            events.MapPost("/", CreateEvent);
            events.MapGet("/", GetAllEvents);
            events.MapGet("/{id}", GetEvent);
            events.MapPut("/{id}", UpdateEvent);
            events.MapDelete("/{id}", DeleteEvent);

            return events;
        }


        //create an event
        static async Task<IResult> CreateEvent(EventDTO newEventDTO, AppDbContext db)
        {
            var newEvent = new Event
            {
                Id = newEventDTO.Id,
                Title = newEventDTO.Title,
                Description = newEventDTO.Description,
                StartTime = newEventDTO.StartTime,
                EndTime = newEventDTO.EndTime,
                Capacity = newEventDTO.Capacity,
            };

            db.Events.Add(newEvent);
            await db.SaveChangesAsync();

            newEventDTO = new EventDTO(newEvent);
            return TypedResults.Created($"/event/{newEvent.Id}", newEventDTO);
        }

        //get all events
        static async Task<IResult> GetAllEvents(AppDbContext db)
        {
            return TypedResults.Ok(
                await db.Events.Select(e => new EventDTO(e)).ToArrayAsync()
                );
        }


        //get event by id
        static async Task<IResult> GetEvent(int id, AppDbContext db)
        {
            return await db.Events.FindAsync(id)
                is Event @event
                ? TypedResults.Ok(new EventDTO(@event))
                : TypedResults.NotFound();
        }

        //update an event

        static async Task<IResult> UpdateEvent(int id, EventDTO inputEventDTO, AppDbContext db)
        {
            var @event = await db.Events.FindAsync(id);

            if (@event is null) return TypedResults.NotFound();

            @event.Title = inputEventDTO.Title;
            @event.Description = inputEventDTO.Description;
            @event.Capacity = inputEventDTO.Capacity;
            @event.StartTime = inputEventDTO.StartTime;
            @event.EndTime = inputEventDTO.EndTime;

            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        //delete an event
        static async Task<IResult> DeleteEvent(int id, AppDbContext db)
        {
            if (await db.Events.FindAsync(id) is null)
            {
                return TypedResults.NotFound();
            }
            else if (await db.Events.FindAsync(id) is Event @event)
            {
                db.Remove(@event);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }
            return TypedResults.NotFound();
        }
    }
}
