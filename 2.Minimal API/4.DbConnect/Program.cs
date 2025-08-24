using _4.DbConnect.DTOs;
using _4.DbConnect.Entities;
using _4.DbConnect.Data;
using _4.DbConnect.Endpoints;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EventDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

//Map Endpoints
app.MapEventEndpoint();



app.Run();
