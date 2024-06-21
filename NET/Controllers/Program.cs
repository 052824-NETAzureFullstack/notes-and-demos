using Microsoft.EntityFrameworkCore;
using Controllers.Data;
using Controllers.Models;
using Controllers.Controller;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Service types/levels -- All about Dependency Injection
// Singleton - one object that is created either at the start of the app or the first time it's needed, that just sticks around until the app closes
// Scoped - only exists for the request we're handling, then it goes away and is recreated with every request that is made.
// Transient - is even more fleeting that a Scoped service, and can be created or deleted in the middle of handling a request.

// DbContext from EF Core is "Scoped" by default.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Docker"));
}); //Scoped by default!

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World");

app.Run();
