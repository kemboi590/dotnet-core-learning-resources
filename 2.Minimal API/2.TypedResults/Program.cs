using _2.TypedResults.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EventDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

//MapGroup API
var events = app.MapGroup("/events");


events.MapPost("/", CreateEvent);
events.MapGet("/", GetAllEvents);
events.MapGet("/{id}", GetEvent);
events.MapPut("/{id}", UpdateEvent);
events.MapDelete("/{id}", DeleteEvent);


//create an event
static async Task<IResult> CreateEvent(Event newEvent, AppDbContext db)
{
    db.Events.Add(newEvent);
    await db.SaveChangesAsync();
    return TypedResults.Created($"/event/{newEvent.Id}", newEvent);
}

//get all events
static async Task<IResult> GetAllEvents(AppDbContext db)
{
    return TypedResults.Ok(await db.Events.ToArrayAsync());
}


//get event by id
static async Task<IResult> GetEvent(int id, AppDbContext db)
{
    return await db.Events.FindAsync(id)
        is Event @event
        ? TypedResults.Ok(@event) : TypedResults.NotFound();
}

//update an event

static async Task<IResult> UpdateEvent(int id, Event inputEvent, AppDbContext db)
{
    var @event = await db.Events.FindAsync(id);

    if (@event is null) return TypedResults.NotFound();

    @event.Title = inputEvent.Title;
    @event.Description = inputEvent.Description;
    @event.Capacity = inputEvent.Capacity;
    @event.StartTime = inputEvent.StartTime;
    @event.EndTime = inputEvent.EndTime;

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


app.Run();
