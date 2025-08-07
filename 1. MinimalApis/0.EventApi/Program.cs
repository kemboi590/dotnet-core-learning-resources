using _0.EventApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EventDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//MapGroup API
var events = app.MapGroup("/events");

//create an event
events.MapPost("/", async (Event newEvent, AppDbContext db) =>
    {
        db.Events.Add(newEvent);
        await db.SaveChangesAsync();
        return Results.Created($"/event/{newEvent.Id}", newEvent);
    });

//get all events
events.MapGet("/", async(AppDbContext db) =>
    await db.Events.ToListAsync());

//get event by id
events.MapGet("/{id}", async (int id, AppDbContext db) =>
await db.Events.FindAsync(id)
is Event @event
? Results.Ok(@event)
: Results.NotFound());

//update an event
events.MapPut("/{id}", async (int id, Event inputEvent, AppDbContext db) =>
{
    var @event = await db.Events.FindAsync(id);

    if (@event is null) return Results.NotFound();

    @event.Title = inputEvent.Title;
    @event.Description = inputEvent.Description;
    @event.Capacity = inputEvent.Capacity;
    @event.StartTime = inputEvent.StartTime;
    @event.EndTime = inputEvent.EndTime;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

//delete an event
events.MapDelete("/{id}", async (int id, AppDbContext db) =>
{
    if (await db.Events.FindAsync(id) is null)
    {
        return Results.NotFound();
    }
    else if (await db.Events.FindAsync(id) is Event @event)
    {
        db.Remove(@event);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NoContent();
});


app.Run();
