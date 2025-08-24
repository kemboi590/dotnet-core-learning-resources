# Transitioning to TypedResults in .NET Minimal APIs

We have been able to get some basics of how minimal APIs work. Now we would like to write clean, readable, and testable code in minimal APIs.

In the **previous codebase**, we used `Results.Ok()`, `Results.Created()`, `Results.NotFound()`, etc. directly inside the lambda functions. We would like to refactor our code by:

1. Moving the logic to **named static methods** (making the code easier to test and reuse)
2. Using **`TypedResults`**, which provides a more explicit and strongly-typed way of returning responses

## What is TypedResults?

`TypedResults` is a class provided by **.NET 7+** that offers type-safe versions of the response helper methods like:

- `TypedResults.Ok(...)`
- `TypedResults.Created(...)`
- `TypedResults.NotFound()`
- `TypedResults.NoContent()`

### Benefits of TypedResults

It helps improve:

- **Readability**: The intent of the method is clearer
- **Tooling support**: IntelliSense and refactoring tools work better
- **Testing**: You can test against expected return types

## Implementation

Update the Program.cs code to the following:

```csharp
using _2.TypedResults.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EventDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// MapGroup API - Groups all event-related endpoints under "/events"
var events = app.MapGroup("/events");

// Map each HTTP verb to its corresponding static method
events.MapPost("/", CreateEvent);
events.MapGet("/", GetAllEvents);
events.MapGet("/{id}", GetEvent);
events.MapPut("/{id}", UpdateEvent);
events.MapDelete("/{id}", DeleteEvent);

// Static method implementations below

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
```

## Comparing Before and After

| Feature        | Old Code (Lambda)          | New Code (TypedResults)                       |
| -------------- | -------------------------- | --------------------------------------------- |
| Return type    | `Results.Ok(...)`        | `TypedResults.Ok(...)`                      |
| Handler format | Inline lambdas             | Separate static methods                       |
| Reusability    | Hard to reuse handlers     | Easy to reuse/test individual methods         |
| Type safety    | Less explicit return types | Strongly-typed result interface (`IResult`) |

### Key Improvements

1. **Separation of Concerns**: Each operation is now in its own method, making the code more organized
2. **Testability**: Static methods can be easily unit tested
3. **Readability**: The Program.cs file is cleaner and easier to understand
4. **Maintainability**: Changes to individual operations don't affect the routing setup
5. **Type Safety**: TypedResults provides better compile-time checking

### Why Use Static Methods?

Static methods for API handlers provide several benefits:

- **No instance required**: They can be called without creating an object
- **Performance**: Slightly better performance as no instance allocation is needed
- **Testing**: Easier to unit test as they don't depend on class state
- **Clarity**: The method signature clearly shows what dependencies are needed

This approach makes your minimal API code more maintainable and follows .NET best practices for organizing API endpoints.
