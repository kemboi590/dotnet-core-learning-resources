using _3._DTOs.Data;
using _3._DTOs.DTOs;
using _3._DTOs.Endpoints;
using _3._DTOs.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EventDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

//Map Endpoints
app.MapEventEndpoint();



app.Run();
